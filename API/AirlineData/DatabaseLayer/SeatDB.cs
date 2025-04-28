using AirlineData.ModelLayer;
using Dapper;
using Microsoft.Data.SqlClient;
namespace AirlineData.DatabaseLayer;

public class SeatDB : ISeatDB
{
    private readonly string _connectionString = "Data Source = localhost; Initial Catalog = Razor; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

    public List<Seat>? GetAllSeats()
    {

        string sql = "SELECT * FROM Seats";

        using SqlConnection con = new(_connectionString);

        con.Open();

        return con.Query<Seat>(sql).ToList();
    }

    public List<Seat>? GetSeatsFromFlight(Flight flight)
    {
        string sql = "SELECT * FROM Seats WHERE flight_id = @Flight_id";

        using SqlConnection con = new(_connectionString);

        con.Open();

        return con.Query<Seat>(sql, new { Flight_id = 1 }).ToList();

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
