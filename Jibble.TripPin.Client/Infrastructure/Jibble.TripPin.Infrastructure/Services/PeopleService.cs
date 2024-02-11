using Jibble.TripPin.Application.Interfaces.Services;
using Jibble.TripPin.Application.Models;
using Jibble.TripPin.Shared;
using Microsoft.OData.Client;

namespace Jibble.TripPin.Infrastructure;

public sealed class PeopleService : IPeopleService
{
    private readonly TripPinServiceContext  _serviceContext;

    public PeopleService(TripPinServiceContext serviceContext)
    {
        ArgumentNullException.ThrowIfNull(nameof(serviceContext));
        _serviceContext = serviceContext;
    }

    public Task<PaginatedResult<PersonDto>> GetPeopleAsync(int pageNumber = 1, int pageSize = 10)
    {
         return _serviceContext.People.ToListAsync<PersonDto>(pageNumber, pageSize);
    }
    
    public Task<PersonDto> GetPersonByUserNameAsync(string userName)
    { 
        return Task.Run<PersonDto>(() =>  _serviceContext.People.Where(p => p.UserName == userName).FirstOrDefault());
        
    }

    public Task<List<PersonDto>> SearchAsync(string criteria)
    {
        return Task.Run<List<PersonDto>>( () =>
            { 
                var query = _serviceContext.People
                            .Where(p => p.UserName.Contains(criteria) ||
                                    p.LastName.Contains(criteria) ||
                                    p.FirstName.Contains(criteria) ||
                                    p.Emails.Any(m => m.Contains(criteria)));
                                    
                return query.ToList<PersonDto>();
            });
    }

    public async Task<PersonDto> UpdateNamesAsync(string userName, string lastName, string firstName)
    {
        PersonDto? personUpdated = null;
        var person = _serviceContext.People.Where(p => p.UserName == userName).Single();
        person.LastName = lastName;
        person.FirstName = firstName;

        _serviceContext.UpdateObject(person);
        var responses = await _serviceContext.SaveChangesAsync(); 
        foreach (var response  in responses)
        {
            var changeResponse = (ChangeOperationResponse) response;
            var entityDescriptor = (EntityDescriptor) changeResponse.Descriptor;
            personUpdated = entityDescriptor.Entity as PersonDto;
        }
        return personUpdated;
    }
}
