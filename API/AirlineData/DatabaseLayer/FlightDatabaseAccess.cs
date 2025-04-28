using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer
{
    public class FlightDatabaseAccess
    {
        public List<Flight> Flights = new List<Flight>();

        public FlightDatabaseAccess()
        {
            // Airplane airplane1 = new("1", "UCNDK787", 8, 4, 2);
            // Airplane airplane2 = new("2", "UCNdfjds", 6, 3, 2);

            Airplane airplane1 = new() { AirplaneId = "1", Airline = "UCNDK787", SeatRows = 4, SeatColumns = 2 };
            Airplane airplane2 = new() { AirplaneId = "2", Airline = "UCNdfjds", SeatRows = 3, SeatColumns = 2 };

            Seat seat1 = new() { SeatName = "1A", IsBooked = true };
            Seat seat2 = new() { SeatName = "1B", IsBooked = true };
            Seat seat3 = new() { SeatName = "1C", IsBooked = false };
            Seat seat4 = new() { SeatName = "1D", IsBooked = true };
            Seat seat5 = new() { SeatName = "2A", IsBooked = false };
            Seat seat6 = new() { SeatName = "2B", IsBooked = true };
            Seat seat7 = new() { SeatName = "2C", IsBooked = false };
            Seat seat8 = new() { SeatName = "2D", IsBooked = true };

            List<Seat> seatList1 = new() { seat1, seat2, seat3, seat4, seat5, seat6, seat7, seat8 };
            FlightRoute flightRoute1 = new() { DepartureAirport = "Copenhagen", ArrivalAirport = "Nuuk" };
            FlightRoute flightRoute2 = new() { DepartureAirport = "Nuuk", ArrivalAirport = "Copenhagen" };
            DateTime departureDate1 = new DateTime(2025, 10, 1, 14, 30, 0);
            DateTime departureDate2 = new DateTime(2025, 10, 5, 16, 30, 0);
            List<Seat> seatList2 = new() { seat1, seat2, seat3, seat5, seat6, seat7 };
            // Flight flight1 = new() { Departure = departureDate1, ListOfSeats = seatList1, airplane = airplane1, route = flightRoute1 };
            // Flight flight2 = new() { Departure = departureDate2, ListOfSeats = seatList2, airplane = airplane2, route = flightRoute2 };

            Flight flight1 = new() { Departure = departureDate1, Airplane = airplane1, Route = flightRoute1 };
            Flight flight2 = new() { Departure = departureDate2, Airplane = airplane2, Route = flightRoute2 };
            Flights.Add(flight1);
            Flights.Add(flight2);
        }

        public List<Flight> Get()
        {
            return Flights;
        }


    }
}
