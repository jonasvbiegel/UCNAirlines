using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using Microsoft.Data.SqlClient;

namespace APIService.BusinessLayer
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IBooking _bdata;
        public BookingLogic(IBooking b)
        {
            _bdata = b;
        }
        public bool CreateBooking(Booking booking)
        {
            try
            {
                _bdata.CreateBooking(booking);
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;
        }
    }
}
