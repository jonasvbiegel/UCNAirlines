using APIService.BusinessLayer;
using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Components.Forms.Mapping;

namespace APIService.BusinessLayer;

public class SeatLogic : ISeatLogic
{

    private readonly string _connectionString = "Data Source = localhost; Initial Catalog = UCNAirlines; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

    private readonly ISeatDB _seatDB;

    public SeatLogic(ISeatDB seatDB)
    {
        _seatDB = seatDB;
    }

    public List<Seat?>? GetSeats()
    {
        return _seatDB.GetAllSeats() ?? null;
    }

    public List<Seat?>? GetSeatsFromFlight(int flightId)
    {
        return _seatDB.GetSeatsFromFlight(flightId) ?? null;
    }

    public Seat? GetSeat(int seatId)
    {
        return _seatDB.GetSeat(seatId) ?? null;
    }

    public bool TryBookSeats(List<Seat?>? seats)
    {
        return _seatDB.TryUpdateSeats(seats);
    }

    public bool UpdateSeat(Seat seat)
    {
        try
        {
            _seatDB.UpdateSeat(seat);
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return true;
    }
}
