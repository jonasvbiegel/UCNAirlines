namespace AirlineData.Model;

public class Seat
{
    public string? SeatName { get; set; }
    public bool IsBooked { get; set; }
    public Flight? Flight { get; set; }
}
