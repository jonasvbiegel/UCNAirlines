using AirlineData.ModelLayer;
using APIService.DTOs;

namespace APIService.ModelConversion
{
    public class BookingDTOConversion
    {
        public static List<Booking>? ToBookingCollection(List<BookingDTO> bsDTO)
        {
            List<Booking>? bs = null;
            if (bsDTO != null)
            {
                bs = new List<Booking>();
                Booking temp;
                foreach (BookingDTO bDTO in bsDTO)
                {
                    temp = ToBooking(bDTO);
                    bs.Add(temp);

                }
            }
            return bs;
        }
        public static BookingDTO FromBooking(Booking b)
        {
            BookingDTO? bDto = null;
            if (b != null)
            {
                
                bDto = new BookingDTO()
                {
                 Flight=FlightDTOConvert.FromFlight(b.Flight),
                 Passengers=PassengerDTOConversion.FromPassengerCollection(b.Passengers)

                };
            }
            return bDto;
        }


        public static Booking? ToBooking(BookingDTO bDto)
        {
            Booking? b = null;
            if (bDto != null)
            {
                b = new Booking()
                {
                    Flight=FlightDTOConvert.ToFlight(bDto.Flight),
                    Passengers=PassengerDTOConversion.ToPassengerCollection(bDto.Passengers)    
                };

            }
            return b;
        }
    }
}
