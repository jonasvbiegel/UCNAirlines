namespace UCNAirlinesWebpage.Models
{
    public class BookingCreationModel
    {
        public int Passengers { get; set; }

        public Flight? Flight { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
