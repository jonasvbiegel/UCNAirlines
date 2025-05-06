using System.Data;
using AirlineData.ModelLayer;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AirlineData.DatabaseLayer
{
    internal class BookingDB : IBookingDB
    {
        private readonly string _connectionString = "Data Source = localhost; Initial Catalog = UCNAirlines; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

        public List<Booking> GetAllBookings()
        {
            string sql = @" SELECT * FROM Booking
                            JOIN Flight ON flight_id_FK = flight_id
                            JOIN Airplane ON airplane_id_Fk = airplane_id
                            JOIN Flight_Route ON flight_route_id_FK = flight_route_id
                          ";

            using SqlConnection con = new(_connectionString);
            con.Open();

            using var reader = con.ExecuteReader(sql);

            List<Booking> bookings = new();

            while (reader.Read())
            {
                bookings.Add(CreateBookingFromReader(reader));
            }
            return bookings;
        }


        public Booking? GetBookingFromFlightId(int flightId)
        {
            string sql = @" SELECT
                            booking.booking_id, flight.flight_id, flight.flight_departure, airplane.airplane_id, airplane.airline, airplane.seat_rows, airplane.seat_columns, flight_Route.flight_route_id, flight_Route.start_destination, flight_Route.end_destination 
                            FROM Booking booking
                            JOIN Flight ON flight_id_FK = flight_id
                            JOIN Airplane ON airplane_id_Fk = airplane_id
                            JOIN Flight_Route ON flight_route_id_FK = flight_route_id
                            WHERE flight_id = @Flight_id";

            Booking? foundBooking = null;

            using SqlConnection con = new(_connectionString);
            con.Open();

            using var reader = con.ExecuteReader(sql, new { Flight_id = flightId });

            while (reader.Read())
            {
                foundBooking = CreateBookingFromReader(reader);
            }
            return foundBooking;
        }

        Booking? IBookingDB.GetBookingFromId(int bookingId)
        {
            string sql = @"SELECT * FROM Booking 
                           SELECT * FROM Booking
                           JOIN Flight ON flight_id_FK = flight_id
                           JOIN Airplane ON airplane_id_Fk = airplane_id
                           JOIN Flight_Route ON flight_route_id_FK = flight_route_id
                           WHERE booking_id = @Booking_id";

            Booking? foundBooking = null;

            using SqlConnection con = new(_connectionString);
            con.Open();

            using var reader = con.ExecuteReader(sql, new { Booking_id = bookingId });

            while (reader.Read())
            {
                foundBooking = CreateBookingFromReader(reader);
            }
            return foundBooking;
        }

        Booking? UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        private Booking CreateBookingFromReader(int booking_id)
        {

            string sql = "SELECT * FROM Flight WHERE flight_id = @Flight_id";

            using SqlConnection con = new(_connectionString);

            var reader = con.ExecuteReader(sql, new { Booking_id = booking_id });

            int flightRouteId = (int)reader["flight_route_id"];

            Tuple<Airport, Airport> airports = FindAirports(flightRouteId);

            Airport start = airports.Item1;
            Airport end = airports.Item2;

            FlightRoute flightRoute = new()
            {
                FlightRouteId = (int)reader["flight_route_id"],
                StartDestination = start,
                EndDestination = end
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
                Route = flightRoute,
                Seats = new List<Seat?>()
            };

            Booking booking = new()
            {
                BookingId = (int)reader["booking_id"]

            };
            return booking;
        }
    }
}
