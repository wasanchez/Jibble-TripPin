using Microsoft.OData.Client;

namespace Jibble.TripPin.Application.Models;


public class PersonDto
{
    public required string UserName { get; set; }
    public required string FirstName { get; set; }
    public required  string LastName { get; set; }
    public required string MiddleName { get; set; }
    public required string Gender { get; set; }
    public int Age { get; set; }
    public List<string> Emails { get; set; } = new List<string>(); 
    public List<LocationDto> AddressInfo { get; set; } = new List<LocationDto>();  
    public LocationDto? HomeAddress { get; set; } 
    public string? FavoriteFeature { get; set; }
    public List<string>? Features { get; set; }
    public List<PersonDto>? Friends { get; set; }
    public PersonDto? BestFriend { get; set; }
    
}
