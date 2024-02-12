namespace Jibble.TripPin.Application.Features.People.Queries;

public class GetPersonByUserNameDto
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Gender { get; set; }
    public int Age { get; set; }
    public string? Emails { get; set; }
    public string? AddressInfo { get; set; }
    public string? HomeAddress { get; set; } 
    public string? FavoriteFeature { get; set; }
    public string? Features { get; set; }
    public string? Friends { get; set; }
    public string? BestFriend { get; set; }
}
