using Jibble.TripPin.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jibble.TripPin.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection servcices, IConfiguration configuration   ) {
        
       return AddODataServices(servcices, configuration);
    }

    private static IServiceCollection AddODataServices(this IServiceCollection servcices, IConfiguration configuration ) {
         var serviceRoot = configuration.GetConnectionString("TripPinServiceConnection");
         var uri = new Uri(serviceRoot);

         servcices
            .AddSingleton(typeof(TripPinServiceContext), new TripPinServiceContext(uri))
            .AddSingleton<IPeopleService, PeopleService>();
            
         return servcices;

    }

}
