namespace AirlineData.Model;

public class Airplane
{
    public string? AirplaneId { get; set; }
    public string? Model { get; set; }
    public int Capacity { get; }
    public int SeatRows { get; set; }
    public int SeatColumns { get; set; }

    public Airplane()
    {
        Capacity = SeatRows * SeatColumns;
    }
}
