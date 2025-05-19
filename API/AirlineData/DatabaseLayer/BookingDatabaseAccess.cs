using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineData.ModelLayer;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AirlineData.DatabaseLayer
{
   public class BookingDatabaseAccess:IBooking
    {
        private readonly string? _connectionString;

        public BookingDatabaseAccess(IConfiguration inConfig)
        {

            _connectionString = inConfig.GetConnectionString("CompanyConnection");
        }

       

        public bool CreateBooking(Booking booking)
        {
            int bookingId = 0;
            string insertBookingQuery = @"
                    INSERT INTO Booking (flight_id_FK) 
                    OUTPUT INSERTED.booking_id 
                    VALUES (@FlightId)";

            string insertPassengerBookingQuery = @"
                        INSERT INTO PassengerBooking (booking_id_FK, passport_no_FK) 
                        VALUES (@BookingId, @PassportNo)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                bookingId = con.ExecuteScalar<int>(insertBookingQuery, new { FlightId = booking.Flight?.FlightId });
                if (booking.Passengers.Count> 0)
                {
                    
                    foreach (var passenger in booking.Passengers)
                    {
                        
                            con.Execute(insertPassengerBookingQuery, new
                            {
                                BookingId = bookingId,
                                PassportNo = passenger.PassportNo
                            });
                        }
                    }
                }



                return bookingId >  0;
            }
        }
    }
