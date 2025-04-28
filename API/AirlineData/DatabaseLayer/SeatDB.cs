using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer;

public class SeatDB : ISeatDB
{
    public List<Seat>? GetAllSeats()
    {
        throw new NotImplementedException();
    }
    public List<Seat>? GetSeatsFromFlight(string airline, DateTime departure)
    {
        throw new NotImplementedException();
    }

    public Seat? GetSeat(int seatId)
    {
        throw new NotImplementedException();
    }

    public Seat? CreateSeat(Seat seat)
    {

        throw new NotImplementedException();
    }

    public bool Delete(int seatId)
    {

        throw new NotImplementedException();
    }
}
