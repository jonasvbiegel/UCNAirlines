namespace UCNAirlinesWebpage.Models
{
    public class Airplane
    {
        public string AirplaneId { get; set; }
        public string AirplaneModel { get; set; }
        public int SeatColumns { get; set; }
        public int SeatRows { get; set; }
        public int Capacity { get; }

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
