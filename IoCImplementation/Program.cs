using IoCImplementation.DependencyInjection;

namespace IoCImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new DiServiceCollection();

            services.RegisterSingleton(new RandomNumberGenerator());

            var container = services.GenerateContainer();

            var ServiceFirst = container.GetService<RandomNumberGenerator>();
            var ServiceSecond = container.GetService<RandomNumberGenerator>();

            Console.WriteLine(ServiceFirst.RandNum == ServiceSecond.RandNum); // Should print True

            //var service = container.GetService<DiContainer>();
        }
    }
}
