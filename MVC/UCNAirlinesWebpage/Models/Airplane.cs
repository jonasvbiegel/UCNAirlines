using Newtonsoft.Json;

namespace UCNAirlinesWebpage.Models
{
    public class Airplane
    {
        [JsonProperty]
        public string AirplaneId { get; set; }
        [JsonProperty]
        public string AirplaneModel { get; set; }
        [JsonProperty]
        public int SeatColumns { get; set; }
        [JsonProperty]
        public int SeatRows { get; set; }
        [JsonProperty]
        public int Capacity { get; }
        public Airplane()
        {
        }
        public Airplane(string airplaneId, string airplaneModel, int seatColumns, int seatRows)
        {
            AirplaneId = airplaneId;
            AirplaneModel = airplaneModel;
            SeatColumns = seatColumns;
            SeatRows = seatRows;
            Capacity = seatColumns * seatRows;

        }

        public Airplane(string airplaneModel)
        {
            AirplaneId = airplaneModel;
            AirplaneModel = airplaneModel;
        }
    }
    
}
