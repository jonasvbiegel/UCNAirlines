using AirlineData.ModelLayer;

namespace APIService.DTOs
{
    public class SeatDTO
    {
        public int SeatNumber { get; set; }
        public string? SeatName { get; set; }
        public PassengerDTO? Passenger { get; set; }
    }
}
