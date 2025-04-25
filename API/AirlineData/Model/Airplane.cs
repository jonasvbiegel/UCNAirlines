namespace AirlineData.Model;

public class Airplane
{
    public string? AirplaneId { get; set; }
    public string? Model { get; set; }
    public int Capacity
    {
        get
        {
            return SeatRows * SeatColumns;
        }
    }
    public int SeatRows { get; set; }
    public int SeatColumns { get; set; }

}
