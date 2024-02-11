using Jibble.TripPin.Console.Controllers;
using Jibble.TripPin.Console.Views;

namespace Jibble.TripPin.Console;

public class App
{
    private readonly IServiceProvider _serviceProvider;

    public App(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        _serviceProvider = serviceProvider;
    }

    public async Task Start() {
        IMenuView view = new MenuView();
        IController controller = new MenuController(view, _serviceProvider);
        await controller.LoadViewAsync();
    }

}
