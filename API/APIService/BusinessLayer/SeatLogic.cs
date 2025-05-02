using APIService.BusinessLayer;
using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using Microsoft.Data.SqlClient;

namespace APIService.BusinessLayer;

public class SeatLogic : ISeatLogic
{
    private readonly ISeatDB seatDB = new SeatDB();

    public List<Seat?>? GetSeats()
    {
        return seatDB.GetAllSeats() ?? null;
    }

    public List<Seat?>? GetSeatsFromFlight(int flightId)
    {
        return seatDB.GetSeatsFromFlight(flightId) ?? null;
    }

    public Seat? GetSeat(int seatId)
    {
        return seatDB.GetSeat(seatId) ?? null;
    }

    public bool UpdateSeat(int seatId, string passportNo)
    {
        try
        {
            seatDB.UpdateSeat(seatId, passportNo);
        }
        catch (SqlException)
        {
            return false;
        }
        return true;
    }
}
