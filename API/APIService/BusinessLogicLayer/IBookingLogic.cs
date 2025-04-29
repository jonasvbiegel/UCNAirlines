using APIService.DTOs;

namespace APIService.BusinessLogicLayer
{
    public interface IBookingLogic
    {
        int CreateBooking(BookingDTO bookingDto);

    }
}
