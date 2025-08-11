using IoCImplementation.Clients;
using IoCImplementation.DependencyInjection;

namespace IoCImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new DiServiceCollection();

            //services.RegisterSingleton(new RandomNumberGenerator());
            services.RegisterTransient<IClient, ClientFirst>();

            var container = services.GenerateContainer();

            var ServiceFirst = container.GetService<IClient>();
            var ServiceSecond = container.GetService<IClient>();

            ServiceFirst.LogMessage("Nigga");
        }
    }
}
