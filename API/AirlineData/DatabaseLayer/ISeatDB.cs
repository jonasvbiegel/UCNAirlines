using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer;

public interface ISeatDB
{
    public List<Seat?>? GetAllSeats();
    public List<Seat?>? GetSeatsFromFlight(int flightRouteId);
    public Seat? GetSeat(int seatId);
    public bool TryUpdateSeats(List<Seat?>? seats);
    public bool UpdateSeat(Seat seat);
}
