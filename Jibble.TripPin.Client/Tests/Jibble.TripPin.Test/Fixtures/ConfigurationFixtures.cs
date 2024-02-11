namespace Jibble.TripPin.Test;

public class ConfigurationFixtures
{

    public IDictionary<string, string>?  InMemorySettings => new Dictionary<string, string> {
        {"ConnectionStrings:TripPinServiceConnection",  "https://services.odata.org/V4/TripPinServiceRW/"}
    } ;


}
