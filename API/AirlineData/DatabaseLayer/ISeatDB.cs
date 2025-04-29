using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer;

public interface ISeatDB
{
    public List<Seat>? GetAllSeats();
    public List<Seat>? GetSeatsFromFlight(int flightRouteId);
    public Seat? GetSeat(int seatId);
    public Seat? CreateSeat(Seat seat);
    public Seat? UpdateSeat(Seat seat);
    public bool Delete(int seatId);
}
