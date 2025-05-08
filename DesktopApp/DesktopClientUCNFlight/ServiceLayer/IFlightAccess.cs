using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public interface IFlightAccess
    {
       public Task<List<Flight>?> GetFlights(DateOnly date);
    }
}
