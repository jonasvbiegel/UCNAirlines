namespace APIService.Model;

public class Flight
{
    public DateTime Datetime { get; set; }
    public List<Seat>? Seats { get; set; }
}
