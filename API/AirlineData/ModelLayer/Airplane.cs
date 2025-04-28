using System.Text.Json.Serialization;

namespace AirlineData.ModelLayer
{
    public class Airplane
    {
        [JsonIgnore]
        public string AirplaneId { get; set; }

        public string Airline { get; set; }

        public int Capacity { get; set; }

        public int SeatColumns { get; set; }

        public int SeatRows { get; set; }

        public Airplane(string airline, int capacity, int seatColumns, int seatRows)
        {
            Airline = airline;
            Capacity = capacity;
            SeatColumns = seatColumns;
            SeatRows = seatRows;
        }
    
        public Airplane(string airplaneId, string airline, int capacity, int seatColumns, int seatRows):this(airline,capacity,seatColumns,seatRows)
        {
            AirplaneId = airplaneId;
            
        }
    }
}
