namespace UCNAirlinesWebpage.Models
{
    public class Flight
    {
        public DateTime Departure { get; set; }

        public Flight(DateTime departure)
        {
            Departure = departure;
        }

       
    }
}
