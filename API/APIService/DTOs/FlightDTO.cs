using AirlineData.ModelLayer;

namespace APIService.DTOs
{
    public class FlightDTO
    {
        
        public int FlightId { get; set; }
        public DateTime Departure_time_and_date { get; set; }
        public List<SeatDTO> Seats { get; set; }
        public AirplaneDTO Airplane { get; set; }
        public FlightRouteDTO Route { get; set; }
        

    }
}

