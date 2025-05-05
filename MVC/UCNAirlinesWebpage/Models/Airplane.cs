using Newtonsoft.Json;

namespace UCNAirlinesWebpage.Models
{
    public class Airplane
    {
        [JsonProperty]
        public string AirplaneId { get; set; }

        [JsonProperty("airline")]
        public string Airline { get; set; }
        [JsonProperty]
        public int SeatColumns { get; set; }
        [JsonProperty]
        public int SeatRows { get; set; }
        [JsonProperty]
        public int Capacity { get; }

        public Airplane()
        {
        }
        public Airplane(string airplaneId, int seatColumns, int seatRows)

        {
            AirplaneId = Airline;
            AirplaneModel = airplaneModel;
            SeatColumns = seatColumns;
            SeatRows = seatRows;
            Capacity = seatColumns * seatRows;

        }

    }
    
}
