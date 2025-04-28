using AirlineData.ModelLayer;
using Dapper;
using Microsoft.Data.SqlClient;
namespace AirlineData.DatabaseLayer;

public class SeatDB : ISeatDB
{
    private readonly string _connectionString = "Data Source = localhost; Initial Catalog = UCNAirlines; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

    public List<Seat>? GetAllSeats()
    {

        // string sql = "SELECT FROM Seats";


        // string sql = @"SELECT * FROM Seat 
        //     INNER Join Flight on flight_id_FK = flight_id 
        //     INNER JOIN Airplane on airplane_id_FK = airplane_id
        //     INNER JOIN Flight_Route on flight_route_id_FK = flight_route_id 
        //     INNER JOIN Airport startdest on start_destination_FK = startdest.icao_code 
        //     INNER JOIN Airport enddest ON end_destination_FK = enddest.icao_code 
        //     INNER JOIN City_Zip_Code zipstart on startdest.zipcode_FK = zipstart.zipcode 
        //     INNER JOIN City_Zip_Code zipend ON enddest.zipcode_FK = zipend.zipcode 
        //     INNER JOIN Country startcountry on zipstart.country_id_FK = startcountry.country_id 
        //     INNER JOIN Country endcountry ON zipend.country_id_FK = endcountry.country_id";

        string sql = @"SELECT * FROM Seat s 
            INNER Join Flight f on s.flight_id = f.flight_id 
            INNER JOIN Airplane a ON f.airplane_id = a.airplane_id 
            INNER JOIN Flight_Route fr on f.flight_route_id = fr.flight_route_id 
            INNER JOIN Airport startdest on fr.start_destination = startdest.icao_code 
            INNER JOIN Airport enddest ON fr.end_destination = enddest.icao_code 
            INNER JOIN City_Zip_Code zipstart on startdest.zipcode = zipstart.zipcode 
            INNER JOIN City_Zip_Code zipend ON enddest.zipcode = zipend.zipcode 
            INNER JOIN Country startcountry on zipstart.country_id = startcountry.country_id 
            INNER JOIN Country endcountry ON zipend.country_id = endcountry.country_id";

        using SqlConnection con = new(_connectionString);
        con.Open();

        var seats = con.Query<Seat, Flight, Airplane, FlightRoute, Airport, Airport, Seat>(sql, (seat, flight, airplane, flightroute, airportstart, airportend) =>
        {
            flightroute.StartDestination = airportstart;
            flightroute.EndDestination = airportend;
            flight.Route = flightroute;
            flight.Airplane = airplane;
            seat.Flight = flight;
            return seat;
        },
        splitOn: "flight_id, flight_route_id, start_destination, end_destination, zipcode, country_id");

        return seats.ToList();
    }

    public List<Seat>? GetSeatsFromFlight(Flight flight)
    {
        string sql = "SELECT * FROM Seats WHERE flight_id = @Flight_id";

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
}
