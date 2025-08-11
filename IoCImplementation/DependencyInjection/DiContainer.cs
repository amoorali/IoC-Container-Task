namespace IoCImplementation.DependencyInjection
{
    public class DiContainer
    {
        private List<ServiceDescriptor> _serviceDescriptors;

        public DiContainer(List<ServiceDescriptor> serviceDescriptors)
        {
            // Initialize the container
            _serviceDescriptors = serviceDescriptors;
        }

        public T? GetService<T>()
        {
            // This method should return an instance of T from the container.
            var descriptor = _serviceDescriptors
                .SingleOrDefault(d => d.ServiceType == typeof(T))
                ?? throw new Exception($"Service of type {typeof(T).Name} isn't registered.");
            
            if (descriptor.Implementation != null) return (T)descriptor.Implementation;

            var implementation = (T)Activator
                .CreateInstance(descriptor.ImplementationType ?? descriptor.ServiceType)!;

            if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                // If the service is a singleton, we store the instance in the descriptor
                descriptor.Implementation = implementation;
            }

            return implementation;
        }
    }
}
