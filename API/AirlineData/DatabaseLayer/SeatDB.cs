using System.Data;
using AirlineData.ModelLayer;
using Dapper;
using Microsoft.Data.SqlClient;
namespace AirlineData.DatabaseLayer;

public class SeatDB : ISeatDB
{
    private readonly string _connectionString = "Data Source = localhost; Initial Catalog = UCNAirlines; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

    public List<Seat>? GetAllSeats()
    {

        string sql = @"SELECT * FROM Seat 
                    JOIN Flight ON flight_id_FK = flight_id 
                    JOIN Airplane ON airplane_id_FK = airplane_id 
                    JOIN Flight_Route ON flight_route_id_FK = flight_route_id";

        using SqlConnection con = new(_connectionString);
        con.Open();

        using var reader = con.ExecuteReader(sql);

        List<Seat> seats = new();

        while (reader.Read())
        {
            seats.Add(CreateSeatFromReader(reader));
        }

        return seats;
    }

    public List<Seat>? GetSeatsFromFlight(int flightRouteId)
    {
        string sql = @"SELECT * FROM Seat 
                    JOIN Flight ON flight_id_FK = flight_id 
                    JOIN Airplane ON airplane_id_FK = airplane_id 
                    JOIN Flight_Route ON flight_route_id_FK = flight_route_id 
                    WHERE flight_id = @flight_id";

        using SqlConnection con = new(_connectionString);
        con.Open();

        using var reader = con.ExecuteReader(sql, new { flight_id = flightRouteId });

        List<Seat> seats = new();

        while (reader.Read())
        {
            seats.Add(CreateSeatFromReader(reader));
        }

        return seats;

        // throw new NotImplementedException();
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

    private Seat CreateSeatFromReader(IDataReader reader)
    {
        int flightRouteId = (int)reader["flight_route_id"];

        Tuple<Airport, Airport> airports = FindAirports(flightRouteId);

        Airport airportStart = airports.Item1;
        Airport airportEnd = airports.Item2;

        FlightRoute flightRoute = new()
        {
            FlightRouteId = (int)reader["flight_route_id"],
            StartDestination = airportStart,
            EndDestination = airportEnd
        };

        Airplane airplane = new()
        {
            AirplaneId = (string)reader["airplane_id"],
            Airline = (string)reader["airline"],
            SeatRows = (int)reader["seat_rows"],
            SeatColumns = (int)reader["seat_columns"]
        };

        Flight flight = new()
        {
            FlightId = (int)reader["flight_id"],
            Departure = (DateTime)reader["datetime"],
            Airplane = airplane,
            Route = flightRoute
        };

        Seat seat = new()
        {
            SeatId = (int)reader["seat_id"],
            SeatName = (string)reader["seat_name"],
            IsBooked = (bool)reader["is_booked"],
            Flight = flight
        };

        return seat;
    }

    private Tuple<Airport, Airport> FindAirports(int id)
    {
        string? startIcao;
        string? endIcao;

        Airport[] airports = new Airport[2];

        using SqlConnection con = new(_connectionString);

        string startIcaoSql = $"SELECT start_destination_FK FROM Flight_Route WHERE flight_route_id = {id}";
        string endIcaoSql = $"SELECT end_destination_FK FROM Flight_Route WHERE flight_route_id = {id}";

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
