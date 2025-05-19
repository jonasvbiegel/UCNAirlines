using UCNAirlinesWebpage.Models;
<<<<<<< HEAD

namespace UCNAirlinesWebpage.ServiceLayer
{
    public interface ISeatAccess
    {
      Task<List<Seat>?> GetSeats(int flightId);
        Task<bool> UpdateSeat(Seat seat);
=======
>>>>>>> develop

namespace UCNAirlinesWebpage.ServiceLayer
{
  public interface ISeatAccess
  {
    Task<List<Seat>?> GetSeats(int flightId);
    Task<bool> UpdateSeat(Seat seat);

  }
}
