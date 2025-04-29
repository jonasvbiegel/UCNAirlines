namespace UCNAirlinesWebpage.Models
{
    public class FlightSearchModel
    {
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Date { get; set; }
        public string? Passenger { get; set; }

        public List<Flight>? Flights { get; set; }
    }
}
