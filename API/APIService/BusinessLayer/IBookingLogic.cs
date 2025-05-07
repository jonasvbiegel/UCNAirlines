using AirlineData.ModelLayer;

namespace APIService.BusinessLayer
{
    public interface IBookingLogic
    {
        public bool CreateBooking(Booking booking);
    }
}
