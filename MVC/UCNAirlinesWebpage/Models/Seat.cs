using Newtonsoft.Json;

namespace UCNAirlinesWebpage.Models
{
    public class Seat
    {

        [JsonProperty("SeatNumber")]
        public int SeatId { get; set; }
        public string? SeatName { get; set; }
        public Passenger? Passenger { get; set; }

    }
}
