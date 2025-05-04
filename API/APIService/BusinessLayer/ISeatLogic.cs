namespace APIService.BusinessLayer;
using AirlineData.ModelLayer;

public interface ISeatLogic
{
    public List<Seat?>? GetSeats();
    public List<Seat?>? GetSeatsFromFlight(int flightId);
    public Seat? GetSeat(int seatId);
    public bool UpdateSeat(Seat seat);
}
