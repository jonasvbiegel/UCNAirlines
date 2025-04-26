using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer
{
    public class SeatDatabaseAccess
    {
        public List<Seat> Seats { get; set; }
        public List<Flight> Flights { get; }
        public SeatDatabaseAccess()
        {
            Airplane a1 = new() { AirplaneId = "CES123", Model = "Cessna", SeatRows = 2, SeatColumns = 2 };
            Airplane a2 = new() { AirplaneId = "BOE123", Model = "Boeing", SeatRows = 2, SeatColumns = 2 };
            DateTime departure = DateTime.Parse("04/24/2025 20:00:00");
            Flight f1 = new() { Airplane = a1, Departure = departure };
            Flight f2 = new() { Airplane = a2, Departure = departure };

            Flights = new() { f1, f2 };

            Seat s1 = new() { SeatName = "1A", IsBooked = false, Flight = f1 };
            Seat s2 = new() { SeatName = "1B", IsBooked = false, Flight = f1 };
            Seat s3 = new() { SeatName = "2A", IsBooked = false, Flight = f1 };
            Seat s4 = new() { SeatName = "2B", IsBooked = false, Flight = f1 };

            Seat s5 = new() { SeatName = "1A", IsBooked = false, Flight = f2 };
            Seat s6 = new() { SeatName = "1B", IsBooked = false, Flight = f2 };
            Seat s7 = new() { SeatName = "2A", IsBooked = false, Flight = f2 };
            Seat s8 = new() { SeatName = "2B", IsBooked = false, Flight = f2 };

            Seats = new() { s1, s2, s3, s4, s5, s6, s7, s8 };
        }
    }
}
