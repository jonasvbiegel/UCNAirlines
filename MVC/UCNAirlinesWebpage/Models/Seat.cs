namespace UCNAirlinesWebpage.Models
{
    public class Seat
    {
        public string SeatId { get; set; }
        public string? SeatName { get; set; }
        public Passenger? Passenger { get; set; }

    }
}
