using UCNAirlinesWebpage.Models;

namespace UCNAirlineApp.Models
{
    public class Flight
    {
        public Flightroute Route { get; set; }
        public Airplane Airplane { get; set; }
        public DateTime Departure { get; set; }

        public Flight(Flightroute route, Airplane airplane, DateTime departure)
        {
            Route = route;
            Airplane = airplane;
            Departure = departure;
        }
    }
}
