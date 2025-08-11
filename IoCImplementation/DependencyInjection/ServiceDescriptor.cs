namespace IoCImplementation.DependencyInjection
{
    public class ServiceDescriptor
    {
        public ServiceDescriptor(object implementation, ServiceLifetime lifetime)
        {
            ServiceType = implementation.GetType();
            Implementation = implementation;
            Lifetime = lifetime;
        }

        public ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
        {
            ServiceType = serviceType;
            Lifetime = lifetime;
        }

        public Type ServiceType { get; }

        public object Implementation { get; internal set; }

        public ServiceLifetime Lifetime { get; }
    }
}
