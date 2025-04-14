namespace API.Model;

public class Airplane
{
    public required string Airplane_id { get; set; }
    public required string Model { get; set; }
    public int Seat_rows { get; set; }
    public int Seat_columns { get; set; }
}
