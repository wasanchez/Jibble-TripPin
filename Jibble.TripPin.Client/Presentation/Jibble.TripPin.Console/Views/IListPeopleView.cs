using Jibble.TripPin.Console.Controllers;
using Jibble.TripPin.Console.Models;

namespace Jibble.TripPin.Console.Views;

public interface IListPeopleView : IView<ListPeopleModel>
{
     string InputOption { get; set; }
     void SetController(ListPeopleController controller);
     

}
