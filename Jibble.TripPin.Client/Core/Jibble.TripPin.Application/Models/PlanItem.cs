namespace Jibble.TripPin.Application.Models;

public class PlanItemDto
{
    public int PlanItemId { get; set; }
    public string? ConfirmationCode { get; set; }
    public DateTimeOffset StartsAt { get; set; }
    public DateTimeOffset EndsAt { get; set; }

}
