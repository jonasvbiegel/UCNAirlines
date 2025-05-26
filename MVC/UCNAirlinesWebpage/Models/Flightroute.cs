using Newtonsoft.Json;

namespace UCNAirlinesWebpage.Models
{
    public class Flightroute
    {
        public int flightRouteId { get; set; }
        public Airport? StartDestination { get; set; }
        public Airport? EndDestination { get; set; }
    
        public Flightroute(Airport startDestination, Airport endDestination)
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
