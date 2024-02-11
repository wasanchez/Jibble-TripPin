using Jibble.TripPin.Application.Models;
using Microsoft.OData.Client;

namespace Jibble.TripPin.Infrastructure;

public sealed class TripPinServiceContext : DataServiceContext
{
    public DataServiceQuery<PersonDto> People { get; }
    public DataServiceQuery<LocationDto> Locations { get; set; }
    public DataServiceQuery<CityDto> Cities { get; set; }
    public DataServiceQuery<PlanItemDto> PlanItems { get; set; }
    public DataServiceQuery<Trip> Trips { get; set; }

    public TripPinServiceContext(Uri serviceRoot) : base(serviceRoot)
    {
        this.People = base.CreateQuery<PersonDto>("People");
        this.Cities = base.CreateQuery<CityDto>("Cities");
        this.Locations = base.CreateQuery<LocationDto>("Locations");
        this.PlanItems = base.CreateQuery<PlanItemDto>("PlanItems");
        this.Trips = base.CreateQuery<Trip>("Trips");
         
        this.Format.UseJson(); 
    }
}
