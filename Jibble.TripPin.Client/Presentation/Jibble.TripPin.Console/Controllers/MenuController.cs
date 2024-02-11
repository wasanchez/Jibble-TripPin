using Jibble.TripPin.Console.Controllers;
using Jibble.TripPin.Console.Models;
using Jibble.TripPin.Console.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Jibble.TripPin.Console;

public class MenuController : IController
{
    private readonly IMenuView _view;
    private readonly IServiceProvider _serviceProvider;

    public MenuController(IMenuView view, IServiceProvider  serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _view = view;
        _view.SetController(this);
    }

    private List<MenuItem>  CreateMenu() {
        
        var menuItems = new List<MenuItem> () {
            new MenuItem {Id = (int) MenuOptions.ListPeople, Name = "List people"},
            new MenuItem {Id = (int) MenuOptions.SearchPeople, Name = "Search people"},
            new MenuItem {Id = (int) MenuOptions.FindAPerson, Name = "Find a person"},
            new MenuItem {Id = (int) MenuOptions.Quit, Name = "Quit"}
        };
      
       return menuItems;
    }

    public async Task DisplayOption(MenuItem menuItem) {
        
        switch (menuItem.Id)
        {
            case (int)MenuOptions.ListPeople:
                await DisplayListOfPeopleScreen();
                break;
            case (int)MenuOptions.SearchPeople:
                await DisplaySearchPeopleScreen();
                break;
            case (int)MenuOptions.FindAPerson:
                break;    
            case (int)MenuOptions.Quit:
                Quit();
                break;
            default:
                _view.Display();
                break;
        }
    }

    public Task LoadViewAsync()
    {
         _view.MenuItems = CreateMenu();
         _view.Display();
         return Task.CompletedTask;
    }

    private async Task DisplayListOfPeopleScreen() 
    {
        var controller = _serviceProvider.GetService(typeof(ListPeopleController)) as ListPeopleController;
        await controller.LoadViewAsync();
    }

    private async Task DisplaySearchPeopleScreen() {
         var controller = _serviceProvider.GetService(typeof(SearchPeopleController)) as SearchPeopleController;
        await controller.LoadViewAsync();
    }

    private void Quit() {
        System.Console.WriteLine("\n");
        Environment.Exit(0);
    }
}
