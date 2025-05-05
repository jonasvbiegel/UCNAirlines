
namespace UCNAirlinesWebpage.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public Flightroute Route { get; set; }
        public Airplane Airplane { get; set; }
        public DateTime Departure { get; set; }

        public Flight(int id, Flightroute route, Airplane airplane, DateTime departure)
        {
            Id = id;
            Route = route;
            Airplane = airplane;
            Departure = departure;
        }

    }
}
