using AirlineData.ModelLayer;

namespace APIService.DTOs
{
    public class FlightRouteDTO
    {
        public AirportDTO? StartDestination { get; set; }
        public AirportDTO? EndDestination { get; set; }
    }
}
