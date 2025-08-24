using IoCImplementation.Clients;
using IoCImplementation.DependencyInjection;

namespace IoCImplementation.Tests;

public class UnitTest
{
    [Fact]
    public void Singleton_Test()
    {
        var services = new DiServiceCollection();

        services.RegisterSingleton<IClient, ClientFirst>();
        services.RegisterTransient<ILogger, Logger>();

        var container = services.GenerateContainer();

        var serviceFirst = container.GetService<IClient>();
        var serviceSecond = container.GetService<IClient>();

        Assert.Equal(serviceFirst.Id, serviceSecond.Id);
        Assert.Equal(serviceFirst.Name, serviceSecond.Name);

        serviceFirst.Id = 50;
        serviceFirst.Name = "Ali";
        
        Assert.Equal(serviceSecond.Id, 50);
        Assert.Equal(serviceSecond.Name, "Ali");
    }

    [Fact]
    public void Transient_Test()
    {
        var services = new DiServiceCollection();

        services.RegisterTransient<IClient, ClientFirst>();
        services.RegisterTransient<ILogger, Logger>();

        var container = services.GenerateContainer();

        var serviceFirst = container.GetService<IClient>();
        var serviceSecond = container.GetService<IClient>();

        Assert.Equal(serviceFirst.Id, serviceSecond.Id);
        Assert.Equal(serviceFirst.Name, serviceSecond.Name);

        serviceFirst.Id = 50;
        serviceFirst.Name = "Ali";

        Assert.NotEqual(serviceSecond.Id, 50);
        Assert.NotEqual(serviceSecond.Name, "Ali");
    }
}
