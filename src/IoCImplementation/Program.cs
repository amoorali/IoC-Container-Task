using IoCImplementation.DependencyInjection;
using IoCImplementation.Clients;

namespace IoCImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new DiServiceCollection();

            services.RegisterSingleton<IClient, ClientFirst>();
            services.RegisterTransient<ILogger, Logger>();

            var container = services.GenerateContainer();

            var serviceFirst = container.GetService<IClient>();
            var serviceSecond = container.GetService<IClient>();

            serviceSecond.LogMessage($"Id: {serviceSecond.Id}, Name: {serviceSecond.Name}");

            serviceFirst.Id = 50;
            serviceFirst.Name = "Ali";

            serviceSecond.LogMessage($"Id: {serviceSecond.Id}, Name: {serviceSecond.Name}");
        }
    }
}
