namespace AirlineData.Model;

public class Flight
{
    public Airplane? Airplane { get; set; }
    public DateTime Datetime { get; set; }
    public List<Seat>? Seats { get; set; }
}
