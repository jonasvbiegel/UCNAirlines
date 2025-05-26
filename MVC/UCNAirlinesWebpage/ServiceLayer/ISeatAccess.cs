using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.ServiceLayer
{
  public interface ISeatAccess
  {
    Task<List<Seat>?> GetSeats(int flightId);
    Task<bool> TryUpdateSeats(List<Seat> seats);
    Task<Seat> GetSeatBySeatID(int seatId);

    }
}
