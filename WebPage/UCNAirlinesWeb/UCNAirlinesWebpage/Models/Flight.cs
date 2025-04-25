using UCNAirlinesWebpage.Models;

namespace UCNAirlineApp.Models
{
    public class Flight
    {
        public Flightroute Route { get; set; }
        public Airplane Airplane { get; set; }
        public string Departure { get; set; }

        public Flight(Flightroute route, Airplane airplane, string departure)
        {
            Route = route;
            Airplane = airplane;
            Departure = departure;
        }
    }
}
