namespace UCNAirlinesWebpage.ServiceLayer
{
    public class BookingServiceAccess : ServiceConnection, IBookingAccess
    {
        public BookingServiceAccess() : base("https://localhost:7184/api/bookings/")
        {

        }
    }
}
