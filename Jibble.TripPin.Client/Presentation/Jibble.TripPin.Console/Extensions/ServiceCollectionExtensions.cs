using Jibble.TripPin.Console.Controllers;
using Jibble.TripPin.Console.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Jibble.TripPin.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddControllers(this IServiceCollection services) {
        return services
            .AddViews()
            .AddSingleton<MenuController>()
            .AddSingleton<ListPeopleController>();

    }

    public static IServiceCollection AddViews(this IServiceCollection services) {
        return services
            .AddSingleton<IMenuView, MenuView>()
            .AddSingleton<IListPeopleView, ListPeopleView>();

    }

}
