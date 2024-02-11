using Jibble.TripPin.Console.Models;

namespace Jibble.TripPin.Console.Views;

public class MenuView : IMenuView
{
    private MenuController _controller;
    public MenuModel Model { get; set; }
    public int MenuOption { get; set; }
    public List<MenuItem> MenuItems { get; set; }
 
    public void Display()
    {
        System.Console.Clear();
        System.Console.WriteLine( "\t \t Welcome to the TripPin console client\n");
        System.Console.WriteLine("\t \t \t \t Menu\n\n");
        foreach (var item in MenuItems)
        {
            System.Console.WriteLine($"\t \t {item.Id}. {item.Name} \n");
        }
        ReadInput();
    }

    public void ReadInput() 
    {
        string? inputOption = string.Empty;
        int option = 0;
        int minOption = MenuItems.Min(x => x.Id);
        int maxOption = MenuItems.Max(x => x.Id);

        System.Console.Write($"\n\t\t Please select an option from the menu: ");
        
        inputOption = System.Console.ReadLine();
        try
            {
            
            if (int.TryParse(inputOption, out option)){
                if (option >= minOption && option <= maxOption) {
                    //Execute controller action
                    MenuOption = option;
                    var menuItem = MenuItems.Where(i => i.Id == option).Single();
                    SelectMenu(menuItem);
                    
                } else {
                    Display();
                }
            } else {
                Display();
            }
            
            }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error!");
        }    
    }

    public void SetController(MenuController controller)
    {
        _controller = controller;
    }

    public async Task SelectMenu(MenuItem menu)
    {
        await _controller.DisplayOption(menu);
    }
}
