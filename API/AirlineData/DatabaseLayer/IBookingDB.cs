using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer
{
    public interface IBookingDB
    {
        public List<Booking?>? GetAllBookings();
        public Booking? GetBookingFromId(int bookingId);
        public List<Booking?>? GetBookingFromFlightId(int flightId);
        public void AddBooking(Booking? booking);
        public Booking? UpdateBooking(Booking booking);
        public void DeleteBooking(int bookingId);
    }
}
