using AirlineData.Model;
using AirlineData.DataAccessLayer;

namespace AirlineData.BusinessLayer;

public class SeatLogic
{

	static readonly TestData td = new();
	// public List<Seat> Seats = td.Seats;
	public List<Seat> Seats { get; }

	public SeatLogic()
	{
		Seats = td.Seats;
	}

	public Seat? UpdateSeat(Flight flight, string seatName, bool newValue)
	{
		foreach (Seat s in td.Seats)
		{
			if (s.Flight == flight && s.SeatName == seatName)
			{
				s.IsBooked = newValue;
				return s;
			}
		}

		return null;
	}

	public List<Seat>? FindSeatsByFlight(string airplaneId, DateTime dep)
	{
		List<Seat> foundSeats = new();
		foreach (Seat s in td.Seats)
		{
			if (s.Flight.Airplane.AirplaneId == airplaneId && s.Flight.Departure == dep) foundSeats.Add(s);
		}
		return foundSeats;
	}


	// FOR POST SEAT
	//
	// static private char ConvertIntToChar(int i)
	// {
	// 	if (i > 26) return '-';
	// 	return Char.ToUpper(Convert.ToChar(i + 97));
	// }
	//
	// static private List<Seat> GenerateSeats(Airplane airplane)
	// {
	// 	return null;
	//
	// List<Seat> seats = new();
	//
	// for (int i = 1; i < airplane.SeatColumns + 1; i++)
	// {
	// 	for (int j = 1; j < airplane.SeatRows; i++)
	// 	{
	// 		// insert a seat 1A, 1B etc for every seat
	// 	}
	// }
	// }
}
