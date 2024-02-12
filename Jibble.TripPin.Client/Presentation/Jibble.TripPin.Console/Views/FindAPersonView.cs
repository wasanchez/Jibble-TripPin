using Jibble.TripPin.Console.Controllers;
using Jibble.TripPin.Console.Models;

namespace Jibble.TripPin.Console.Views;

public class FindAPersonView : IFindAPersonView
{
    FindAPersonController _controller;
    public FindAPersonModel Model { get; set; }
    public string InputOption { get; set; }

    public FindAPersonView()
    {
        Model = new FindAPersonModel();
    }

    public void Display()
    {
        System.Console.Clear();
        System.Console.WriteLine("\t \t \t \t Find a person by Username\n\n");
        
        System.Console.Write($"{Environment.NewLine}Please enter the Username: ");
        Model.Username = System.Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(Model.Username)) {
            _controller.Find();
        }else {
            Display();
        }
        
    }

    public void ReadInput()
    {
        System.Console.WriteLine($"{Environment.NewLine}New search: N \t\t Return to menu: M");
        System.Console.Write("Enter an option: ");
        InputOption = System.Console.ReadLine().ToUpper();
        if (!string.IsNullOrWhiteSpace(InputOption)) {
            _controller.ExcuteInputOption();
        } else {
            Display();
        }      
    }

    public void SetController(FindAPersonController controller)
    {
        _controller = controller;
    }

    public void LoadResult()
    {
          if (Model.Person != null ) 
          {   
            System.Console.WriteLine($"{Environment.NewLine}Username: {Model.Person.UserName}{Environment.NewLine}Last name: {Model.Person.LastName}{Environment.NewLine}First name: {Model.Person.FirstName}");
            System.Console.WriteLine($"Age: {Model.Person.Age}{Environment.NewLine}Gender: {Model.Person.Gender}");
            System.Console.WriteLine($"Email: {Model.Person.Emails}{Environment.NewLine}Address Info: {Model.Person.AddressInfo}");
            System.Console.WriteLine($"Home address: {Model.Person.HomeAddress}{Environment.NewLine}Favorite feature: {Model.Person.FavoriteFeature}");
            System.Console.WriteLine($"Features: {Model.Person.Features}{Environment.NewLine}Friends: {Model.Person.Friends}");
            System.Console.WriteLine($"Best friend: {Model.Person.BestFriend}");
        }else {
            DisplayMessage("Data not found!");
        }
        ReadInput();
    }

    public void DisplayMessage(string message)
    {
        System.Console.WriteLine($"{Environment.NewLine} {message}");
    }
}
