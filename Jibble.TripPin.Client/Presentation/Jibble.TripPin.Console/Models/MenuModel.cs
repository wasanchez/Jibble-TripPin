namespace Jibble.TripPin.Console;

public class MenuModel : IViewModel
{
    public int SelectedOption { get; set; }
}

public class MenuItem {
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public enum MenuOptions {
    ListPeople = 1,
    SearchPeople,
    FindAPerson,
    Quit
}