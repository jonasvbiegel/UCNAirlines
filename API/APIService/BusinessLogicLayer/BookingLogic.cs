using AirlineData.DatabaseLayer;

namespace APIService.BusinessLogicLayer
{
    public class BookingLogic : IBookingLogic
    {
        private readonly IBookingDatabaseAccess _bookingAccess;

        public BookingLogic(IBookingDatabaseAccess bookingAccess) 
        {
            _bookingAccess = bookingAccess;
        }

        public 

    }
}
