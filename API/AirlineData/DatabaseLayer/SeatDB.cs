using AirlineData.ModelLayer;
using Dapper;
using Microsoft.Data.SqlClient;
namespace AirlineData.DatabaseLayer;

public class SeatDB : ISeatDB
{
    private readonly string _connectionString = "Data Source = localhost; Initial Catalog = UCNAirlines; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

    public List<Seat>? GetAllSeats()
    {

        string sql = @"SELECT * FROM Seat s 
            INNER Join Flight f on s.flight_id_FK = f.flight_id 
            INNER JOIN Airplane a ON f.airplane_id_FK = a.airplane_id 
            INNER JOIN Flight_Route fr on f.flight_route_id_FK = fr.flight_route_id 
            INNER JOIN Airport startdest on fr.start_destination_FK = startdest.icao_code 
            INNER JOIN Airport enddest ON fr.end_destination_FK = enddest.icao_code 
            INNER JOIN City_Zip_Code zipstart on startdest.zipcode_FK = zipstart.zipcode 
            INNER JOIN City_Zip_Code zipend ON enddest.zipcode_FK = zipend.zipcode 
            INNER JOIN Country startcountry on zipstart.country_id_FK = startcountry.country_id 
            INNER JOIN Country endcountry ON zipend.country_id_FK = endcountry.country_id";

        using SqlConnection con = new(_connectionString);
        con.Open();

        // var reader = con.ExecuteReader(sql);
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader reader = cmd.ExecuteReader();

        List<Seat> seats = new();

        while (reader.Read())
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

            seats.Add(seat);
        }

        return seats;
    }

    public List<Seat>? GetSeatsFromFlight(Flight flight)
    {
        string sql = "SELECT* FROM Seats WHERE flight_id = @Flight_id";

        using SqlConnection con = new(_connectionString);

        con.Open();

        return con.Query<Seat>(sql, new { Flight_id = flight.FlightId }).ToList();

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

    private Tuple<Airport, Airport> FindAirports(int id)
    {
        string? startIcao;
        string? endIcao;

        Tuple<Airport, Airport> tuple = new(null, null);

        Airport airportStart;
        Airport airportEnd;

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
                airportStart = new()
                {
                    IcaoCode = startIcao,
                    Country = (string)startReader["country"],
                    AirportName = (string)startReader["airport_name"],
                    City = (string)startReader["city"],
                    Zipcode = (string)startReader["zipcode"]
                };

                airports[0] = airportStart;
            }
        }

        using (var endReader = con.ExecuteReader(endAirportSql))
        {
            while (endReader.Read())
            {
                airportEnd = new()
                {
                    IcaoCode = startIcao,
                    Country = (string)endReader["country"],
                    AirportName = (string)endReader["airport_name"],
                    City = (string)endReader["city"],
                    Zipcode = (string)endReader["zipcode"]
                };

                airports[1] = airportEnd;
            }

        }

        return Tuple.Create(airports[0], airports[1]);

    }
}
