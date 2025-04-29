using AirlineData.ModelLayer;

namespace APIService.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public Customer? Customer { get; set; }
        public Flight Flight { get; set; }

        public BookingDTO(int bookingId, Customer? customer, Flight flight)
        {
            BookingId = bookingId;
            Customer = customer;
            Flight = flight;
        }
    }
}
