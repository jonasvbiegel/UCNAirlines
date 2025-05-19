using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using APIService.DTOs;
using APIService.ModelConversion;
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
        public bool CreateBooking(BookingDTO bDTO)
        {
            Booking booking=BookingDTOConversion.ToBooking(bDTO);
            try
            {
                _bdata.CreateBooking(booking);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
