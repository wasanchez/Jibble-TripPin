using Jibble.TripPin.Console.Controllers;
using Jibble.TripPin.Console.Models;

namespace Jibble.TripPin.Console.Views;

public interface IFindAPersonView : IView<FindAPersonModel>
{
    string InputOption { get; set; }
    void SetController(FindAPersonController controller);
    void LoadResult();
    void DisplayMessage(string message);
}
