using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.ServiceLayer
{
    public interface IPassengerAccess
    {
        Task<Passenger> GetPassenger(string passportNo);
        Task<Passenger> InsertPassenger(Passenger passenger);
    }
}
