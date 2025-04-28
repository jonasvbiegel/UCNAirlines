namespace AirlineData.ModelLayer;

public class Seat
{
    public int SeatId { get; set; }
    public string? SeatName { get; set; }
    public bool IsBooked { get; set; }
    public Flight? Flight { get; set; }
    public Passenger? Passenger { get; set; }

    public override string ToString()
    {
        return $"{SeatId} {SeatName}";
    }
}
