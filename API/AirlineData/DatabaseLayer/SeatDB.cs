using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AirlineData.ModelLayer;
using Dapper;
using Dapper.Transaction;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace AirlineData.DatabaseLayer;

public class SeatDB : ISeatDB
{
    private readonly string? _connectionString;

    public SeatDB(IConfiguration inConfig)
    {

        _connectionString = inConfig.GetConnectionString("CompanyConnection");
    }


    public List<Seat?>? GetAllSeats()
    {

        string sql = "SELECT * FROM Seat FULL OUTER JOIN Passenger ON passport_no_FK = passport_no";

        using SqlConnection con = new(_connectionString);
        con.Open();

        using var reader = con.ExecuteReader(sql);

        List<Seat?> seats = new();

        while (reader.Read())
        {
            Seat? s = CreateSeatFromReader(reader);

            seats.Add(s);
        }

        return seats;
    }


    public Seat? GetSeat(int seatId)
    {
        string sql = "SELECT * FROM Seat FULL OUTER JOIN Passenger ON passport_no_FK = passport_no WHERE seat_id = @SeatId";

        using SqlConnection con = new(_connectionString);
        using var reader = con.ExecuteReader(sql, new { SeatId = seatId });

        Seat? s = new();

        while (reader.Read())
        {
            s = CreateSeatFromReader(reader);
        }

        return s;
    }

    public List<Seat?>? GetSeatsFromFlight(int flightId)
    {
        string sql = @"SELECT * FROM Seat
            FULL OUTER JOIN Passenger ON passport_no_FK = passport_no
            WHERE flight_id_FK = @Flight_id";

        using SqlConnection con = new(_connectionString);

        var reader = con.ExecuteReader(sql, new { @Flight_id = flightId });

        List<Seat?> seats = new();

        while (reader.Read())
        {
            seats.Add(CreateSeatFromReader(reader));

        }

        return seats;
    }


    public bool TryUpdateSeats(List<Seat?>? seats)
    {
        Random rnd = new Random();
        for (; ; )
        {
            foreach (Seat? s in seats)
            {
                Seat? seatReturn = GetSeat(s.SeatId);
                if (seatReturn.Passenger != null)
                {
                    return false;
                }
                ;
            }

            using SqlConnection con = new(_connectionString);
            con.Open();

            using var transaction = con.BeginTransaction(IsolationLevel.ReadUncommitted);

            try
            {
                string sqlUpdate = "UPDATE Seat SET passport_no_FK = @PassportNo WHERE seat_id = @SeatId AND passport_no_FK = null";
                bool result = true;
                foreach (Seat seat in seats)
                {
                    string actualPassport;
                    if (seat.Passenger == null) actualPassport = (string?)null;
                    else
                    {
                        actualPassport = seat.Passenger.PassportNo;
                    }

                    int rowsChanged = con.Execute(sqlUpdate, new
                    {
                        PassportNo = actualPassport,
                        SeatId = seat.SeatId
                    }, transaction);
                    if (rowsChanged == 0)
                    {
                        Console.WriteLine($"Seat {seat.SeatId} was already booked; rolling back and trying again");
                        result = false;
                        break;
                    }
                }
                ;

                if (result)
                {
                    transaction.Commit();
                    return true;
                }
                transaction.Rollback();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaction.Rollback();
            }
            // Thread.Sleep(rnd.Next(1, 10));
            Thread.Sleep(750);
        }
    }


    private Seat? CreateSeatFromReader(IDataReader reader)
    {
        Seat s = new()
        {
            SeatId = (int)reader["seat_id"],
            SeatName = (string)reader["seat_name"],
        };

        if (reader.IsDBNull(2))
        {
            s.Passenger = null;
        }

        else
        {
            Passenger p = new()
            {
                FirstName = (string)reader["first_name"],
                LastName = (string)reader["last_name"],
                BirthDate = DateOnly.FromDateTime((DateTime)reader["birth_date"]),
                PassportNo = (string)reader["passport_no"]
            };
            s.Passenger = p;
        }

        return s;
    }
}

