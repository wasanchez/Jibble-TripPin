using Jibble.TripPin.Application;
using Jibble.TripPin.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jibble.TripPin.Test.IntegrationTests;

public class IntegrationTestBase : IClassFixture<ConfigurationFixtures>
{
     protected IServiceProvider ServiceProvider { get; }
     protected ConfigurationFixtures Fixtures { get; }
    
    public IntegrationTestBase(ConfigurationFixtures fixtures)
    {
        Fixtures = fixtures;
        IServiceCollection services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(Fixtures.InMemorySettings)
                .Build();
        
        services
            .AddLogging()
            .AddApplicationLayer()  
            .AddInfrastructureLayer(configuration);
        
        ServiceProvider = services.BuildServiceProvider();
    }
}
