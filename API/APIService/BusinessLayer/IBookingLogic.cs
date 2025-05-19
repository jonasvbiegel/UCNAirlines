using AirlineData.ModelLayer;
using APIService.DTOs;

namespace APIService.BusinessLayer
{
    public interface IBookingLogic
    {
        public bool CreateBooking(BookingDTO booking);
    }
}
