

namespace IoCImplementation.DependencyInjection
{
    public class DiServiceCollection
    {
        private List<ServiceDescriptor> _serviceDescriptors = [];

        public void RegisterSingleton<T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T), ServiceLifetime.Singleton));
        }

        public void RegisterTransient<T>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(T), ServiceLifetime.Transient));
        }

        internal void RegisterTransient<TService, TImplementation>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
        }

        public DiContainer GenerateContainer()
        {
            return new DiContainer(_serviceDescriptors);
        }
    }
}