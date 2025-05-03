using APIService.BusinessLayer;
using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using Microsoft.Data.SqlClient;

namespace APIService.BusinessLayer;

public class SeatLogic : ISeatLogic
{

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

    public bool UpdateSeat(int seatId, string passportNo)
    {
        try
        {
            _seatDB.UpdateSeat(seatId, passportNo);
        }
        catch (SqlException)
        {
            return false;
        }
        return true;
    }
}
