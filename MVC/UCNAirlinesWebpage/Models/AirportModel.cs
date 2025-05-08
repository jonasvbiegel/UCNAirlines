namespace UCNAirlinesWebpage.Models
{
    public class AirportModel
    {
        List<string> Airports { get; set; }
        public AirportModel(List<string> airports)
        {
            Airports = airports;
        }
    }
}
