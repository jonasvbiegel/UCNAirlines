namespace AirlineData.ModelLayer;

public class Passenger
{
    public string? PassportNo { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public bool Baggage { get; set; }
    public Booking? Booking { get; set; }
}
