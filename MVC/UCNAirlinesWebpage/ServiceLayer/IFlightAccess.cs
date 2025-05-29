using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.ServiceLayer
{
    public interface IFlightAccess
    {
       public Task<List<Flight>?> GetFlights(string date);
        public Task<Flight?> GetFlight(int flightId);
    }
}
