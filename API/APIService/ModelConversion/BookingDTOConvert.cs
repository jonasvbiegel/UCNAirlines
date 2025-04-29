using AirlineData.ModelLayer;
using APIService.DTOs;

namespace APIService.ModelConversion
{
    public class BookingDTOConvert
    {

        // Convert from Booking object to BookingDTO object
        public static BookingDTO? FromBooking(Booking booking)
        {
            BookingDTO? ABookingReadDto = null;
            if (booking != null)
            {
                ABookingReadDto = new BookingDTO(booking.BookingId, booking.Customer, booking.Flight);
            }
            return ABookingReadDto;
        }

        // Convert from BookingDTO object to Booking object
        public static Booking? ToBooking(BookingDTO bookingDto)
        {
            Booking? ABookingReadDto = null;
            if (bookingDto != null)
            {
                ABookingReadDto = new Booking(bookingDto.BookingId, bookingDto.Customer, bookingDto.Flight);
            }
            return ABookingReadDto;
        }
    }
}
