using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineData.ModelLayer;
using Microsoft.Data.SqlClient;

namespace AirlineData.DatabaseLayer
{
    internal class BookingDB : IBookingDB
    {
        public List<Booking?>? GetAllBooking()
        {
           
        }

        public List<Booking?>? GetBookingFromFlight(int flightRouteId)
        {
            
        }

        public Booking? GetBooking(int bookingId)
        {
            
        }

        public Booking? UpdateBooking(BookingDatabaseAccess booking)
        {
            
        }
    }
}
