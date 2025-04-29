using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer
{
    public class FlightDatabaseAccess:IFlightDatabaseAccess
    {
        public List<Flight> Flights = new List<Flight>();

        public FlightDatabaseAccess()
        {
            

            //Airplane airplane1 = new("1", "UCNAirlines", 8, 4, 2);
            //Airplane airplane2 = new("2", "UCNAirlines", 6, 3, 2);

            //Seat seat1 = new("1A", true);
            //Seat seat2 = new("1B", true);
            //Seat seat3 = new("1C", false);
            //Seat seat4 = new("1D", true);
            //Seat seat5 = new("2A", false);
            //Seat seat6 = new("2B", false);
            //Seat seat7 = new("2C", false);
            //Seat seat8 = new("2D", true);
            //List<Seat> seatList1 = new() { seat1, seat2, seat3, seat4, seat5, seat6, seat7, seat8 };
            //Airport a1 = new("Aalborg Lufthavn", "AAL", "9400", "Aalborg", "Denmark");
            //Airport a2 = new("Nuuk Airport", "BGGH", "3905", "Nuuk", "Greenland");
            //FlightRoute flightRoute1 = new(a1, a2);
            //FlightRoute flightRoute2 = new(a2, a1);
            //DateTime departureDate1 = new DateTime(2025, 10, 1, 14, 30, 0);
            //DateTime departureDate2 = new DateTime(2025, 10, 5, 16, 30, 0);
            //List<Seat> seatList2 = new() { seat1, seat2, seat3, seat5, seat6, seat7 };
            //Flight flight1 = new(1, departureDate1, airplane1, flightRoute1);
            //flight1.ListOfSeats = seatList1;
            //Flight flight2 = new(2, departureDate2, airplane2, flightRoute2);
            //flight2.ListOfSeats = seatList2;
            //Flights.Add(flight1);
            //Flights.Add(flight2);
        }

        public List<Flight> GetAllFlights()
        {
            return Flights;
        }
        public Flight GetFlightById(int id)
        {
            Flight flight = null;
            foreach (Flight f in Flights)
            {
                if (f.FlightId == id)
                {
                    flight = f;
                }
            }
            return flight;
        }

        public List<Flight> GetAllFlightsByDate(DateTime date)
        {
            List<Flight> flights = new List<Flight>();
            foreach (Flight f in Flights)
            {
                if (f.Departure.Date == date.Date)
                {
                    flights.Add(f);
                }
            }
            return flights;
        }

        public int CreateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFlightById(int id)
        {
            throw new NotImplementedException();
        }
        public bool UpdateFlight(Flight flight)
        {
            throw new NotImplementedException();
        }

        
    }
}
