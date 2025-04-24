namespace AirlineData.BusinessLayer;
using AirlineData.Model;

public class SeatLogic
{

	static private char ConvertIntToChar(int i)
	{
		if (i > 26) return '-';
		return Char.ToUpper(Convert.ToChar(i + 97));
	}

	static private List<Seat> GenerateSeats(Airplane airplane)
	{
		return null;

		// List<Seat> seats = new();
		//
		// for (int i = 1; i < airplane.SeatRows + 1; i++)
		// {
		//
		// }
	}
}
