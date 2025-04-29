using APIService.BusinessLayer;
using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;

namespace APIService.BusinessLayer;

public class SeatLogic : ISeatLogic
{
    private readonly ISeatDB seatDB = new SeatDB();

    public List<Seat?>? GetSeats()
    {
        return seatDB.GetAllSeats() ?? null;
    }

    public List<Seat?> GetSeatsFromFlight(int flightId)
    {
        return seatDB.GetSeatsFromFlight(flightId);
    }

    public Seat? GetSeat(int seatId)
    {
        return seatDB.GetSeat(seatId);
    }

    public Seat? UpdateSeat(Seat seat)
    {
        return seatDB.UpdateSeat(seat);
    }
}
