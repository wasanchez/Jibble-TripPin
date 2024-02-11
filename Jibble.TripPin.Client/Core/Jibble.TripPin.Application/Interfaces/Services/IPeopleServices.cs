using Jibble.TripPin.Application.Models;
using Jibble.TripPin.Shared;

namespace Jibble.TripPin.Application.Interfaces.Services;

public interface IPeopleService
{
    Task<PaginatedResult<PersonDto>> GetPeopleAsync(int pageNumber = 1, int pageSize = 10);
    Task<PersonDto> GetPersonByUserNameAsync(string userName);
    Task<List<PersonDto>> SearchAsync(string criteria);
    Task<PersonDto> UpdateNamesAsync(string userName, string lastName, string firstName);
}
