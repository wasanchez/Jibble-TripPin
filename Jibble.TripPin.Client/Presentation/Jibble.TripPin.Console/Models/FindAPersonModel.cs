using Jibble.TripPin.Application.Features.People.Queries;

namespace Jibble.TripPin.Console.Models;

public class FindAPersonModel : IViewModel
{
    public string? Username { get; set; }

    public GetPersonByUserNameDto? Person { get; set; } 

}
