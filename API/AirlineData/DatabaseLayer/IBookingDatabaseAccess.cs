using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer
{
    public interface IBookingDatabaseAccess
    {
        int CreateBooking(Booking bookingAdd);
    }
}
