using Jibble.TripPin.Application.Features.People.Queries;

namespace Jibble.TripPin.Console;

public class ListPeopleModel : IViewModel
{
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    public int CurrentPage { get; set; } = 1;
    public int TotalPages { get; set; } = 1;
    public int MoveToPage { get; set; } = 1;
    public List<GetPeopleWithPaginationDto> Items { get; set; } = new List<GetPeopleWithPaginationDto>();

}
