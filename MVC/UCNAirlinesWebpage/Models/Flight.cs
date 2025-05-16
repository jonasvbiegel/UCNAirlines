
using Newtonsoft.Json;

namespace UCNAirlinesWebpage.Models
{
    public class Flight
    {
        [JsonProperty("id")]
        public int FlightId { get; set; }
        [JsonProperty]
        public DateTime Departure { get; set; }
        [JsonProperty]
        public List<Seat> seats { get; set; }
        [JsonProperty]
        public Airplane Airplane { get; set; }

        [JsonProperty]
        public Flightroute Route { get; set; }
        public Flight() { }

        public Flight(Flightroute route, Airplane airplane, DateTime departure)
        {

            Route = route;
            Airplane = airplane;
            Departure = departure;
        }

    }
}
