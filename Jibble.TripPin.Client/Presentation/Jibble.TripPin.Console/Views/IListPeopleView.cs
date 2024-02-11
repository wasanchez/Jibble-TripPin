using Jibble.TripPin.Console.Controllers;

namespace Jibble.TripPin.Console.Views;

public interface IListPeopleView : IView<ListPeopleModel>
{
     string InputOption { get; set; }
     void SetController(ListPeopleController controller);
     

}
