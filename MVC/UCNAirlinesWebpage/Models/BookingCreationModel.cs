namespace UCNAirlinesWebpage.Models
{
    public class BookingCreationModel
    {
        public int Passengers { get; set; }

        public int SelectedFlight { get; set; }

        public List<Flight>? Flights { get; set; }
    }
}
