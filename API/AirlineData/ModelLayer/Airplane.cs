using System.Text.Json.Serialization;

namespace AirlineData.ModelLayer;

public class Airplane
{
    public string? AirplaneId { get; set; }

    public string? Airline { get; set; }
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
