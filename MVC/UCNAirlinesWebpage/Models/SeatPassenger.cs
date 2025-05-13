namespace UCNAirlinesWebpage.Models
{
    public class SeatPassenger
    {
        public Flight Flight { get; set; }
        public int passengerCount {  get; set; }    
        public List<Seat> Seats { get; set; }   
        public List<Passenger> Passengers { get; set; }
        public string? Pass { get; set; }
    }
}
