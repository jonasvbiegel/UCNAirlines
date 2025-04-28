namespace AirlineData.ModelLayer;

public class Customer
{
    public int CustomerId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string? Email { get; set; }
    public string? PhoneNo { get; set; }
}
