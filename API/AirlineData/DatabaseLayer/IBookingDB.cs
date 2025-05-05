using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer
{
    public interface IBookingDB
    {
        public List<Booking?>? GetAllBookings();
        public List<Booking?>? GetBookingFromFlightId(int flightRouteId);
        public Booking? GetBookingFromId(int bookingId);
        public Booking? UpdateBooking(BookingDatabaseAccess booking);
    }
}
