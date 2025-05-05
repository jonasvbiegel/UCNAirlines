using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.Data
{
    public class SeatData
    {
        public static Dictionary<int, List<Seat>> SeatListByFlight = new Dictionary<int, List<Seat>>
        {
            {
                
                1, new List<Seat>
                {
                    new Seat { SeatId = 1, SeatName = "1A", Passenger = new Passenger { PassportNo = "101", FirstName = "Alice" } },
                    new Seat { SeatId = 2, SeatName = "1B", Passenger = null },
                    new Seat { SeatId = 3, SeatName = "1C", Passenger = null },
                    new Seat { SeatId = 4, SeatName = "2A", Passenger = null },
                    new Seat { SeatId = 5, SeatName = "2B", Passenger = null },
                }
            },
            {
                2, new List<Seat>
                {
                    new Seat { SeatId = 6, SeatName = "1A", Passenger =  new Passenger { PassportNo = "101", FirstName = "Alice" }},
                    new Seat { SeatId = 7, SeatName = "1B", Passenger = null },
                    new Seat { SeatId = 8, SeatName = "1C", Passenger = null },
                    new Seat { SeatId = 9, SeatName = "2A", Passenger = null },
                    new Seat { SeatId = 10, SeatName = "2B", Passenger = null },
                }
            }
        };
        public static bool AssignPassengerToSeat(int seatId, Passenger passenger)
        {
            foreach (var flight in SeatListByFlight.Values)
            {
                var seat = flight.FirstOrDefault(s => s.SeatId == seatId);
                if (seat != null)
                {
                    if (seat.Passenger == null)
                    {
                        seat.Passenger = passenger;
                        return true; // Successfully assigned the passenger
                    }
                    else
                    {
                        return false; // Seat is already occupied
                    }
                }
            }
            return false; // Seat not found
        }
    }
}
