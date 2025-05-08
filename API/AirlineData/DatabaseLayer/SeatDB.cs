using System.Data;
using System.Runtime.CompilerServices;
using AirlineData.ModelLayer;
using Dapper;
using Microsoft.Data.SqlClient;
namespace AirlineData.DatabaseLayer;

public class SeatDB : ISeatDB
{
    private readonly string _connectionString = "Data Source = localhost; Initial Catalog = UCNAirlines; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

    public List<Seat?>? GetAllSeats()
    {

        string sql = "SELECT * FROM Seat";

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
        string sql = "SELECT * FROM Seat WHERE seat_id = @SeatId";

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

    // TODO: Concurrency issue here
    // Documentation for row version and concurrency control found here:
    // https://learn.microsoft.com/en-us/sql/t-sql/data-types/rowversion-transact-sql?view=sql-server-ver16

    public bool UpdateSeat(Seat seat)
    {
        string sql =
            @"
            DECLARE @rv rowversion = (SELECT row_version FROM Seat WHERE seat_id = @SeatId);
            DECLARE @key TABLE (seat_id int);
            UPDATE Seat
            SET passport_no_FK = @PassportNo
                OUTPUT inserted.seat_id INTO @key(seat_id)
            WHERE seat_id = @SeatId
                AND row_version = (SELECT row_version FROM Seat WHERE seat_id = @SeatId);
            IF (SELECT COUNT(*) FROM @key) = 0
                BEGIN
                    RAISERROR ('error changing row with seat_id = %d'
                            , 16
                            , 1
                            , 1)
                    END;
            ";


        using SqlConnection con = new(_connectionString);

        string actualPassport;

        if (seat.Passenger == null) actualPassport = (string?)null;
        else
        {
            actualPassport = seat.Passenger.PassportNo;
        }

        int rowsChanged = con.Execute(sql, new
        {
            PassportNo = actualPassport,
            SeatId = seat.SeatId
        });

        return rowsChanged != 0;
    }

    private Passenger? CreatePassengerFromPassportNo(string passportNo)
    {
        string sql = "SELECT * FROM Passenger WHERE passport_no = @Passport_no";

        using SqlConnection connection = new(_connectionString);

        var reader = connection.ExecuteReader(sql, new { Passport_no = passportNo });

        Passenger? p = new();

        while (reader.Read())
        {

            p.FirstName = (string)reader["first_name"];
            p.LastName = (string)reader["last_name"];
            p.BirthDate = DateOnly.FromDateTime((DateTime)reader["birth_date"]);
            p.PassportNo = (string)reader["passport_no"];
        }

        return p;
    }

    // private Flight CreateFlightFromReader(int flight_id)
    // {
    //     string sql = "SELECT * FROM Flight WHERE flight_id = @Flight_id";
    //
    //     using SqlConnection con = new(_connectionString);
    //
    //     var reader = con.ExecuteReader(sql, new { Flight_id = flight_id });
    //
    //     int flightRouteId = (int)reader["flight_route_id"];
    //
    //     Tuple<Airport, Airport> airports = FindAirports(flightRouteId);
    //
    //     Airport start = airports.Item1;
    //     Airport end = airports.Item2;
    //
    //     FlightRoute flightRoute = new()
    //     {
    //         FlightRouteId = (int)reader["flight_route_id"],
    //         StartDestination = start,
    //         EndDestination = end
    //     };
    //
    //     Airplane airplane = new()
    //     {
    //         AirplaneId = (string)reader["airplane_id"],
    //         Airline = (string)reader["airline"],
    //         SeatRows = (int)reader["seat_rows"],
    //         SeatColumns = (int)reader["seat_columns"]
    //     };
    //
    //     Flight flight = new()
    //     {
    //         FlightId = (int)reader["flight_id"],
    //         Departure = (DateTime)reader["datetime"],
    //         Airplane = airplane,
    //         Route = flightRoute,
    //         Seats = new List<Seat?>()
    //     };
    //
    //     return flight;
    // }

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
            s.Passenger = CreatePassengerFromPassportNo((string)reader["passport_no_FK"]);
        }

        return s;
    }

    private Tuple<Airport, Airport> FindAirports(int id)
    {
        string? startIcao;
        string? endIcao;

        Airport[] airports = new Airport[2];

        using SqlConnection con = new(_connectionString);

        string startIcaoSql = $"SELECT start_destination_FK FROM Flight_Route WHERE flight_route_id = @id";
        string endIcaoSql = $"SELECT end_destination_FK FROM Flight_Route WHERE flight_route_id = ";

        startIcao = con.Query<string>(startIcaoSql).FirstOrDefault();
        endIcao = con.Query<string>(endIcaoSql).FirstOrDefault();

        string startAirportSql = $"SELECT * FROM Airport JOIN City_Zip_Code ON zipcode_FK = zipcode JOIN Country ON country_id_FK = country_id WHERE icao_code = '{startIcao}'";
        string endAirportSql = $"SELECT * FROM Airport JOIN City_Zip_Code ON zipcode_FK = zipcode JOIN Country ON country_id_FK = country_id WHERE icao_code = '{endIcao}'";

        using (var startReader = con.ExecuteReader(startAirportSql))
        {
            while (startReader.Read())
            {
                airports[0] = new()
                {
                    IcaoCode = startIcao,
                    Country = (string)startReader["country"],
                    AirportName = (string)startReader["airport_name"],
                    City = (string)startReader["city"],
                    Zipcode = (string)startReader["zipcode"]
                };
            }
        }

        using (var endReader = con.ExecuteReader(endAirportSql))
        {
            while (endReader.Read())
            {
                airports[1] = new()
                {
                    IcaoCode = endIcao,
                    Country = (string)endReader["country"],
                    AirportName = (string)endReader["airport_name"],
                    City = (string)endReader["city"],
                    Zipcode = (string)endReader["zipcode"]
                };
            }
        }

        return Tuple.Create(airports[0], airports[1]);
    }
}
