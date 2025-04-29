namespace APIService.BusinessLayer;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;

public interface ISeatLogic
{
    public List<Seat?>? GetSeats();
    public List<Seat?>? GetSeatsFromFlight(int flightId);
    public Seat GetSeat(int seatId);
    public Seat UpdateSeat(Seat seat);
}
