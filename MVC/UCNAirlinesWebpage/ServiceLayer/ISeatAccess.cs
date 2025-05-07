using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.ServiceLayer
{
    public interface ISeatAccess
    {
      Task<List<Seat>?> GetSeats(int flightId);
        Task<bool> UpdateSeat(Seat seat);

    }
}
