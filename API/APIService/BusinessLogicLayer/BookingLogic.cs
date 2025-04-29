using System;
using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using APIService.DTOs;

namespace APIService.BusinessLogicLayer
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IBookingDatabaseAccess _bookingAccess;

        public BookingLogic(IBookingDatabaseAccess bookingAccess) 
        {
            _bookingAccess = bookingAccess;
        }

        public int CreateBooking(BookingDTO bookingAdd)
        {
            int insertedId = 0;
            try
            {
                Booking? newBooking = ModelConversion.BookingDTOConvert.ToBooking(bookingAdd);
                if (newBooking != null)
                {
                    insertedId = _bookingAccess.CreateBooking(newBooking);
                }
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
        }
    }
}
