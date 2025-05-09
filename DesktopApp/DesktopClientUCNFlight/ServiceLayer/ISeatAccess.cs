
using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public interface ISeatAccess
    {
      Task<List<Seat>?> GetSeats(int flightId);
        Task<bool> UpdateSeat(Seat seat);

    }
}
