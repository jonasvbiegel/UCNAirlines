using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer;

public interface ISeatDB
{
    public List<Seat>? GetAllSeats();
    public List<Seat>? GetSeatsFromFlight(string airline, DateTime departure);
    public Seat GetSeat(int seatId);
    public Seat? CreateSeat(Seat seat);
    public bool Delete(int seatId);
}
