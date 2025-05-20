using AirlineData.ModelLayer;

namespace APIService.DTOs
{
    public class FlightDTO
    {
        // public FlightDTO(DateTime departure, AirplaneDTO airplane, FlightRouteDTO route, int flightId)
        // {
        //     Departure_time_and_date = departure;
        //     Seats = new List<SeatDTO>();
        //     this.Airplane = airplane;
        //     this.Route = route;
        //     this.FlightId = flightId;
        // }

        public DateTime Departure_time_and_date { get; set; }
        public List<SeatDTO> Seats { get; set; }
        public AirplaneDTO Airplane { get; set; }
        public FlightRouteDTO Route { get; set; }
        public int FlightId { get; set; }

    }
}

