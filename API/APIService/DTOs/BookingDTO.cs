using AirlineData.ModelLayer;

namespace APIService.DTOs
{
    public class BookingDTO
    {
        public List<PassengerDTO?>? Passengers { get; set; }
        public FlightDTO? Flight { get; set; }
    }
}
