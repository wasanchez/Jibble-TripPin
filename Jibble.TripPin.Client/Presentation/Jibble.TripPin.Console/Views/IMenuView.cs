namespace Jibble.TripPin.Console.Views;

public interface IMenuView : IView
{
    void SetController(MenuController controller);
    Task SelectMenu(MenuItem menu);
    public List<MenuItem> MenuItems { get; set; }
    int MenuOption { get; set; }
}
