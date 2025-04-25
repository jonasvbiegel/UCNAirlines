namespace AirlineData.ModelLayer
{
    public class Airplane
    {
        public string AirplaneId { get; set; }

        public string Model { get; set; }

        public int Capacity { get; set; }

        public int SeatColumns { get; set; }

        public int SeatRows { get; set; }

        public Airplane(string model, int capacity, int seatColumns, int seatRows)
        {
            Model = model;
            Capacity = capacity;
            SeatColumns = seatColumns;
            SeatRows = seatRows;
        }
    
        public Airplane(string airplaneId, string model, int capacity, int seatColumns, int seatRows):this(model,capacity,seatColumns,seatRows)
        {
            AirplaneId = airplaneId;
            
        }
    }
}
