namespace AirlineData.ModelLayer;

public class Booking
{
    public int BookingId { get; set; }
    public Customer? Customer { get; set; }
    public Flight Flight { get; set; }

    public Booking(int bookingId, Customer? customer, Flight flight)
    {
        BookingId = bookingId;
        Customer = customer;
        Flight = flight;
    }
}

