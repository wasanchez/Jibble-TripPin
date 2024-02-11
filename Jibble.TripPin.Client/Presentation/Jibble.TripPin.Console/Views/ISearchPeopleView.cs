using Jibble.TripPin.Console.Models;
using Jibble.TripPin.Console.Views;

namespace Jibble.TripPin.Console.Views;

public interface ISearchPeopleView : IView<SearchPeopleModel>
{
    string InputOption { get; set; }
    void SetController(SearchPeopleController controller);
    void LoadResult();
    void DisplayMessage(string message);
}
