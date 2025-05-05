using System.Data;
using AirlineData.ModelLayer;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AirlineData.DatabaseLayer
{
    internal class BookingDB : IBookingDB
    {
        private readonly string _connectionString = "Data Source = localhost; Initial Catalog = UCNAirlines; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

        List<Booking?>? IBookingDB.GetAllBookings()
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

        List<Booking?>? IBookingDB.GetBookingFromFlightId(int flightRouteId)
        {
            throw new NotImplementedException();
        }

        Booking? IBookingDB.GetBookingFromId(int bookingId)
        {
            throw new NotImplementedException();
        }

        Booking? IBookingDB.UpdateBooking(BookingDatabaseAccess booking)
        {
            throw new NotImplementedException();
        }
    }

}
