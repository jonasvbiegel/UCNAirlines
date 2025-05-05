using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.Data
{
    public class FlightData
    {
        public static List<Flight> FlightList = new List<Flight>
        {
            new Flight(1, new Flightroute("Aalborg", "Nuuk"), new Airplane("A1", "Boeing 737", 6, 20), new DateTime(2025, 5, 20, 8, 0, 0)),
            new Flight(2, new Flightroute("Nuuk", "Aalborg"), new Airplane("A2", "Airbus A320", 6, 18), new DateTime(2025, 5, 21, 14, 30, 0)),
        };
        public FlightData()
        {
            // Assign seats to flights
            foreach (var flight in FlightList)
            {
                if (SeatData.SeatListByFlight.ContainsKey(flight.FlightId))
                {
                    flight.Seats = SeatData.SeatListByFlight[flight.FlightId];
                }
            }
        }

        public List<Flight> GetAll()
        {
            return FlightList;
        }

        public Flight GetById(int id)
        {
            return FlightList.FirstOrDefault(f => f.FlightId == id);
        }
    }
}

