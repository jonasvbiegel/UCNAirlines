using AirlineData.ModelLayer;

namespace FlightRestService.DTOs
{
    public class FlightDTO
    {
        public FlightDTO(DateTime departure, Airplane airplane, FlightRoute route)
        {
            Departure = departure;
            ListOfSeats = new List<Seat>();
            this.Airplane = airplane;
            this.Route = route;
        }

        public DateTime Departure { get; set; }
        public List<Seat> ListOfSeats { get; set; }
        public Airplane Airplane { get; set; }
        public FlightRoute Route { get; set; }

    }
}
