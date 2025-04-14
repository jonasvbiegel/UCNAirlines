using MVC.APIAccess;

namespace MVC.Models;

public class Airplane
{
    public required string Airplane_id { get; set; }
    public required string Model { get; set; }
    public int Seat_rows { get; set; }
    public int Seat_columns { get; set; }

    public override string ToString()
    {
        return $"ID: {Airplane_id} | Model: {Model} | Number of seats: {Seat_rows * Seat_columns}";
    }
}
