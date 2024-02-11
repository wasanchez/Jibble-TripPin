using Jibble.TripPin.Console.Controllers;
using Jibble.TripPin.Console.Models;

namespace Jibble.TripPin.Console.Views;

public class ListPeopleView : IListPeopleView
{   
    public ListPeopleModel Model { get; set; }
    public string InputOption { get; set; }

    ListPeopleController  _controller;

    public ListPeopleView()
    {
        Model  = new ListPeopleModel();
    }

    public void Display()
    {
        System.Console.Clear();
        System.Console.WriteLine("\t \t \t \t List People\n\n");
        if (Model.Items.Count > 0 ) {
            System.Console.Write("Next page: N \t\t Previous page: P \t\t Return to menu: M");
            System.Console.WriteLine($"\t\t Page {Model.CurrentPage} of {Model.TotalPages}\n");
            
            System.Console.WriteLine($"{Environment.NewLine}Username \t\tLast name \t\tFirst name \t\t Age \t\t Emails");
            foreach (var item in Model.Items)
            {
                System.Console.WriteLine($"{item.UserName} \t\t{item.LastName} \t\t{item.FirstName} \t\t{item.Age} \t\t{item.Emails}");
            }
        }else {
            System.Console.WriteLine("\n\nData not found!");
        }
        ReadInput();
        
    }

    public void SetController(ListPeopleController controller)
    {
        _controller = controller;
    }

    public void ReadInput()
    {
        System.Console.Write("\nEnter an option: ");
        InputOption = System.Console.ReadLine().ToUpper();
        _controller.ExcuteInputOption();
    }
}
