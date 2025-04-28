using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer;

public class SeatDB : ISeatDB
{
    private readonly string _connectionString = "Data Source = localhost; Initial Catalog = Razor; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

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

    public Seat? UpdateSeat(Seat seat)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int seatId)
    {
        throw new NotImplementedException();
    }
}
