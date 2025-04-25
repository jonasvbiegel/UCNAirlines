namespace AirlineData.ModelLayer
{
    public class Airplane
    {
        public string AirplaneId { get; set; }

        public string Model { get; set; }

        public int Capacity { get; set; }

        public int SeatColumns { get; set; }

        public int SeatRows { get; set; }


        public Airplane(string airplaneId, string model, int capacity, int seatColumns, int seatRows)
        {
            AirplaneId = airplaneId;
            Model = model;
            Capacity = capacity;
            SeatColumns = seatColumns;
            SeatRows = seatRows;
        }
    }
}
