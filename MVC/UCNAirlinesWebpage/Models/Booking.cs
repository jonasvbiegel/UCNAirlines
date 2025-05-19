namespace UCNAirlinesWebpage.Models
{
    public class Booking
    {
        public List<Passenger?>? passengers { get; set; }
        public Flight Flight { get; set; }
    }
}
