using Newtonsoft.Json;

namespace UCNAirlinesWebpage.Models
{
    public class Airplane
    {
        [JsonProperty("Airplane_number")]
        public string AirplaneId { get; set; }
        [JsonProperty]
        public string Airline { get; set; }
        [JsonProperty("ColumnCount")]
        public int SeatColumns { get; set; }
        [JsonProperty("RowCount")]
        public int SeatRows { get; set; }
        [JsonProperty]
        public int Capacity { get; }
        public Airplane()
        {
        }
        public Airplane(string airplaneId, string airline, int seatColumns, int seatRows)
        {
            AirplaneId = airplaneId;
            Airline = airline;
            SeatColumns = seatColumns;
            SeatRows = seatRows;
            Capacity = seatColumns * seatRows;

        }

        public Airplane(string airplaneModel)
        {
            AirplaneId = airplaneModel;
            Airline = airplaneModel;
        }
    }
    
}
