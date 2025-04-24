using AirlineData.Model;

namespace AirlineData.DataAccessLayer;

public class TestData
{
	public List<Seat> Seats { get; }
	public TestData()
	{
		Seat s1 = new() { SeatName = "1A", IsBooked = false };
		Seat s2 = new() { SeatName = "1B", IsBooked = false };
		Seat s3 = new() { SeatName = "1C", IsBooked = false };

		Seats = new() { s1, s2, s3 };
	}
}
