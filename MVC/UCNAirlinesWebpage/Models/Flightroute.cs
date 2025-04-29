namespace UCNAirlinesWebpage.Models
{
    public class Flightroute
    {
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }

        public Flightroute(string startDestination, string endDestination)
        {
            if(startDestination == endDestination)
            {
                throw new ArgumentException("StartDestination and EndDestination cannot be the same!");
            }
            StartDestination = startDestination;
            EndDestination = endDestination;
        }

    }
}
