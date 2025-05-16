using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public interface IFlightAccess
    {
        Task<List<Flight>?> GetFlights(string date);
    }
}
