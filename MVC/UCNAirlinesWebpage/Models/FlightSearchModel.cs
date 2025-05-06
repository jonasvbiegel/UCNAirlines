using Microsoft.AspNetCore.Mvc;

namespace UCNAirlinesWebpage.Models
{
    public class FlightSearchModel
    {
        public string? From { get; set; }
        public string? To { get; set; }
        public DateOnly Date { get; set; }
        
        public int Passenger { get; set; }
        public int SelectedFlight { get; set; }

        public List<Flight>? Flights { get; set; }
    }
}
