namespace UCNAirlinesWebpage.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public List<Passenger?>? Passengers { get; set; }
        public Flight? Flight { get; set; }
    }
}
