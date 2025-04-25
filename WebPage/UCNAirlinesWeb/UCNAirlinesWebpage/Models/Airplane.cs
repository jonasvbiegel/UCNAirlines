namespace UCNAirlinesWebpage.Models
{
    public class Airplane
    {
        public string AirplaneId { get; set; }
        public string Model { get; set; }
        public int SeatColumns { get; set; }
        public int SeatRows { get; set; }
        public int Capacity { get; }

        public Airplane(string airplaneId, string model, int seatColumns, int seatRows)
        {
            AirplaneId = airplaneId;
            Model = model;
            SeatColumns = seatColumns;
            SeatRows = seatRows;
            Capacity = seatColumns * seatRows;
        }
    }
}
