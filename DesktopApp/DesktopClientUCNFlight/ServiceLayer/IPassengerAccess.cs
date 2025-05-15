using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public interface IPassengerAccess
    {
        Task<Passenger> GetPassenger(string passportNo);
        Task<Passenger> InsertPassenger(Passenger passenger);
    }
}
