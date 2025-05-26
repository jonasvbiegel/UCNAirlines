using AirlineData.ModelLayer;

namespace APIService.DTOs
{
    public class FlightRouteDTO
    {
        public int? FlightRouteId { get; set; }
        public AirportDTO? StartDestination { get; set; }
        public AirportDTO? EndDestination { get; set; }
    }
}
