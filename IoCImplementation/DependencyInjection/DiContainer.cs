using System.Reflection;
using System.Reflection.Emit;

namespace IoCImplementation.DependencyInjection
{
    public class DiContainer
    {
        private readonly List<ServiceDescriptor> _serviceDescriptors;

        public DiContainer(List<ServiceDescriptor> serviceDescriptors)
        {
            // Initialize the container
            _serviceDescriptors = serviceDescriptors;
        }

        public T? GetService<T>() => (T)GetService(typeof(T))!;

        private object? GetService(Type serviceType)
        {
            var callStack = new HashSet<Type>();
            return Resolve(serviceType, callStack);
        }

        private object? Resolve(Type serviceType, HashSet<Type> callStack)
        {
            if (callStack.Contains(serviceType))
            {
                throw new InvalidOperationException($"Circular dependency detected for type {serviceType.Name}.");
            }

            callStack.Add(serviceType);

            try
            {
                var descriptor = _serviceDescriptors
                    .LastOrDefault(d => d.ServiceType == serviceType);

                if (descriptor == null)
                {
                    // If no descriptor found, return null
                    throw new Exception($"Service of type {serviceType} isn't registered.");
                }

                if (descriptor.Implementation != null)
                {
                    // If the service is already instantiated, return it
                    return descriptor.Implementation;
                }

                if (descriptor.Lifetime == ServiceLifetime.Singleton)
                {
                    if (descriptor.Implementation != null)
                    {
                        // If the singleton instance is already created, return it
                        return descriptor.Implementation;
                    }

                    // If the service is a singleton, we need to create it only once
                    var instance = CreateInstanceFor(descriptor, callStack);
                    descriptor.Implementation = instance;
                    return instance;
                }

                // If the service is transient, we create a new instance every time
                return CreateInstanceFor(descriptor, callStack);
            }
            finally
            {
                callStack.Remove(serviceType);
            }
        }

        private object CreateInstanceFor(ServiceDescriptor descriptor, HashSet<Type> callStack)
        {
            if (descriptor.Implementation != null) return descriptor.Implementation;

            var implementationType = descriptor.ImplementationType
                                     ?? descriptor.ServiceType
                                     ?? throw new Exception($"No implemenatation provided for {descriptor.ServiceType}");

            var ctors = implementationType.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                                          .OrderByDescending(c => c.GetParameters().Length)
                                          .ToArray();

            if (ctors.Length == 0)
            {
                throw new Exception($"No public constructor found for {implementationType.Name}.");
            }

            foreach (var ctor in ctors)
            { 
                var parameters = ctor.GetParameters();
                var args = new object[parameters.Length];
                var status = true;

                for (int i = 0; i < parameters.Length; i++)
                {
                    var dep = Resolve(parameters[i].ParameterType, callStack);

                    if (dep == null)
                    {
                        status = false;
                        break;
                    }
                    args[i] = dep;
                }

                if (status)
                {
                    // If we successfully resolved all dependencies, create the instance
                    var instance = ctor.Invoke(args);
                    if (descriptor.Lifetime == ServiceLifetime.Singleton)
                    {
                        // If the service is a singleton, we store the instance in the descriptor
                        descriptor.Implementation = instance;
                    }
                    return instance;
                }
            }
            // If we couldn't resolve dependencies for this constructor, try the parameterless constructor
            var parameterlessCtor = implementationType.GetConstructor(Type.EmptyTypes);
            if (parameterlessCtor != null)
            {
                var instance = Activator.CreateInstance(implementationType)!;
                if (descriptor.Lifetime == ServiceLifetime.Singleton)
                {
                    // If the service is a singleton, we store the instance in the descriptor
                    descriptor.Implementation = instance;
                }
                return instance;
            }

            throw new Exception($"Could not resolve dependencies for {implementationType.Name}.");
        }
    }
}
