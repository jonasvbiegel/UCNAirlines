
namespace UCNAirlinesWebpage.Models
{
    public class Flight
    {
        public int FlightId { get;set; }
        public Flightroute Route { get; set; }
        public Airplane Airplane { get; set; }
        public DateTime Departure { get; set; }
        public List<Seat?>? Seats { get; set; }
        public Flight(int id,Flightroute route, Airplane airplane, DateTime departure)
        {
            FlightId = id;
            Route = route;
            Airplane = airplane;
            Departure = departure;
            Seats= new List<Seat?>();   
        }

    }
}
