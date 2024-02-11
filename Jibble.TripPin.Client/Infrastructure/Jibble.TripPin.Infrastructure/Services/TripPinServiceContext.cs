using Jibble.TripPin.Application.Models;
using Microsoft.OData.Client;

namespace Jibble.TripPin.Infrastructure;

public sealed class TripPinServiceContext : DataServiceContext
{
    public DataServiceQuery<PersonDto> People { get; }
    public TripPinServiceContext(Uri serviceRoot) : base(serviceRoot)
    {
        this.People = base.CreateQuery<PersonDto>("People");      
        this.Format.UseJson(); 
    }
}
