namespace IoCImplementation.DependencyInjection
{
    public class ServiceDescriptor(object implementation, ServiceLifetime lifetime)
    {
        public Type ServiceType { get; } = implementation.GetType();

        public object Implementation { get; } = implementation;

        public ServiceLifetime Lifetime { get; } = lifetime;
    }
}
