using Jibble.TripPin.Console.Models;
using Jibble.TripPin.Console.Views;

namespace Jibble.TripPin.Console;

public class SearchPeopleView : ISearchPeopleView
{
    SearchPeopleController _controller;
    public SearchPeopleModel Model { get; set; }
    public string InputOption { get; set; }

    public SearchPeopleView()
    {
        Model = new SearchPeopleModel();
    }

    public void Display()
    {
        System.Console.Clear();
        System.Console.WriteLine("\t \t \t \t Search people\n\n");
        
        System.Console.Write($"{Environment.NewLine}Please enter the data to search: ");
        Model.Filter = System.Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(Model.Filter)) {
            _controller.Search();
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

    public void SetController(SearchPeopleController controller)
    {
        _controller = controller;
    }

    public void LoadResult()
    {
          if (Model.Items.Count > 0 ) 
          {   
            System.Console.WriteLine($"{Environment.NewLine}Username \t\tLast name \t\tFirst name \t\t Age \t\t Emails");
            foreach (var item in Model.Items)
            {
                System.Console.WriteLine($"{item.UserName} \t\t{item.LastName} \t\t{item.FirstName} \t\t{item.Age} \t\t{item.Emails}");
            }
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
