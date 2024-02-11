using FluentValidation;
using Jibble.TripPin.Application.Validators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Jibble.TripPin.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services) {

        return services
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
            .AddMediator()
            .AddValidtors();
        
    }

    private static IServiceCollection AddMediator(this IServiceCollection services) {

        return services.AddMediatR(config => 
        {
            config.AsSingleton();
        }, AppDomain.CurrentDomain.GetAssemblies());
    }   

    private static IServiceCollection AddValidtors(this IServiceCollection services) {
        return services.AddValidatorsFromAssemblyContaining<GetPersonByUserNameQueryValidator>(ServiceLifetime.Singleton);
    }
}
