namespace Jibble.TripPin.Application.Models;

public class Trip
{
    public int TripId { get; set; }
    public Guid ShareId { get; set; }   
    public required string Name { get; set; }
    public required string Budget { get; set; }
    public string? Description { get; set; }
    public required IEnumerable<string> Tags { get; set; }
    public required DateTimeOffset StartsAt { get; set; }
    public required DateTimeOffset EndsAt { get; set; }
    public required IEnumerable<PlanItemDto> PlanItems { get; set; }

}
