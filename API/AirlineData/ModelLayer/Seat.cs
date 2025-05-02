namespace AirlineData.ModelLayer;

public class Seat
{
    public int SeatId { get; set; }
    public string? SeatName { get; set; }
    public Flight? Flight { get; set; }
    public Passenger? Passenger { get; set; }
}
