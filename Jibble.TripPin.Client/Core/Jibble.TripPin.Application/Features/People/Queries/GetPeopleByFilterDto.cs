namespace Jibble.TripPin.Application.Features.People.Queries;

public class GetPeopleByFilterDto
{
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public  string? MiddleName { get; set; }
    public string? Gender { get; set; }
    public int Age { get; set; }
    public string? Emails { get; set; }
}
