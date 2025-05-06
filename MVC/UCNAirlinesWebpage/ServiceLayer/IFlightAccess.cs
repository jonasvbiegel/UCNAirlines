using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.ServiceLayer
{
    public interface IFlightAccess
    {
       public Task<List<Flight>?> GetFlights(DateOnly date);
    }
}
