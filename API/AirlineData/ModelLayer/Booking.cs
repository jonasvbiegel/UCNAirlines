namespace AirlineData.ModelLayer;

public class Booking
{
    public int BookingId { get; set; }
    public List<Passenger?>? Passengers { get; set; }
}
