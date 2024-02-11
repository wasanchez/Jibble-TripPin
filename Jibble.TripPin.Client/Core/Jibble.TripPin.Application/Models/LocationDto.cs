using System.Security.Authentication;

namespace Jibble.TripPin.Application.Models;

public class LocationDto
{
    public string? Address { get; set; }
    public CityDto? City { get; set; }
}
