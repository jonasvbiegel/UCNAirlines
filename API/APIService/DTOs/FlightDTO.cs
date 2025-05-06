using AirlineData.ModelLayer;

namespace APIService.DTOs
{
    public class FlightDTO
    {
        public FlightDTO(DateTime departure, Airplane airplane, FlightRoute route, int flightId)
        {
            FlightId = flightId;
            Departure_time_and_date = departure;    
            Seats = new List<Seat>();
            this.Airplane = airplane;
            this.Route = route;
        }

        public DateTime Departure_time_and_date { get; set; }
        public List<Seat> Seats { get; set; }
        public Airplane Airplane { get; set; }
        public FlightRoute Route { get; set; }
        public int FlightId { get; set; }


    }
}

