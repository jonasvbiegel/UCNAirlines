namespace UCNAirlinesWebpage.Models
{
    public class Flightroute
    {
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }

        public Flightroute(string startDestination, string endDestination)
        {
            StartDestination = startDestination;
            EndDestination = endDestination;
        }
    }
}
