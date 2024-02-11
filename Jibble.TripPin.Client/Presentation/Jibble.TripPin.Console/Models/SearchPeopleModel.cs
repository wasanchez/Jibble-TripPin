using Jibble.TripPin.Application.Features.People.Queries;

namespace Jibble.TripPin.Console.Models;

public class SearchPeopleModel : IViewModel
{
    public string? Filter { get; set; }

    public List<GetPeopleByFilterDto> Items { get; set; } = new List<GetPeopleByFilterDto>();

}
