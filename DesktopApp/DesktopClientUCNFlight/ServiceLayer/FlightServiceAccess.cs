using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public class FlightServiceAccess : IFlightServiceAccess
    {
        //ALT i denne klasse skal skiftes til API kald

        private List<Flight> flights;

        public FlightServiceAccess()
        {
            // Vi opretter dummy-data i konstruktøren
            flights = new List<Flight>();
            CreateDummyFlights();
        }

        // Oprettet nogle flyvninger fra Aalborg til Nuuk med sæder
        private void CreateDummyFlights()
        {
            // flyet
            Airplane airplane = new Airplane
            {
                AirplaneId = "ABC123",
                Airline = "UCN Airlines",
                SeatRows = 2,
                SeatColumns = 3
            };

            // start- og slut-lufthavne
            Airport aalborg = new Airport
            {
                IcaoCode = "AAL",
                AirportName = "Aalborg Airport",
                City = "Aalborg",
                Country = "Denmark"
            };

            Airport nuuk = new Airport
            {
                IcaoCode = "GOH",
                AirportName = "Nuuk Airport",
                City = "Nuuk",
                Country = "Greenland"
            };

            FlightRoute route = new FlightRoute
            {
                FlightRouteId = 1,
                StartDestination = aalborg,
                EndDestination = nuuk
            };

            // flyvninger for 23.-28. juni 2025
            DateTime startDate = new DateTime(2025, 6, 23);
            DateTime endDate = new DateTime(2025, 6, 28);

            int flightIdCounter = 1;

            while (startDate <= endDate)
            {
                // 3 flyvninger per dag: kl. 08:00, 13:00 og 18:00
                List<DateTime> departureTimes = new List<DateTime>
                {
                    startDate.AddHours(8),
                    startDate.AddHours(13),
                    startDate.AddHours(18)
                };

                foreach (DateTime departure in departureTimes)
                {
                    Flight flight = new Flight
                    {
                        FlightId = flightIdCounter,
                        Departure = departure,
                        Airplane = airplane,
                        Route = route,
                        Seats = CreateSeats()
                    };

                    flights.Add(flight);
                    flightIdCounter = flightIdCounter + 1;
                }

                startDate = startDate.AddDays(1);
            }
        }

        // Opret sæder til flyet
        private List<Seat> CreateSeats()
        {
            List<Seat> seats = new List<Seat>();

            // Vi laver sæderne 1A, 1B, 1C, 2A, 2B, 2C
            seats.Add(new Seat { SeatId = 1, SeatName = "1A", Passenger = null });
            seats.Add(new Seat { SeatId = 2, SeatName = "1B", Passenger = null });
            seats.Add(new Seat { SeatId = 3, SeatName = "1C", Passenger = null });
            seats.Add(new Seat { SeatId = 4, SeatName = "2A", Passenger = null });
            seats.Add(new Seat { SeatId = 5, SeatName = "2B", Passenger = null });
            seats.Add(new Seat { SeatId = 6, SeatName = "2C", Passenger = null });

            return seats;
        }

        // Returner alle flyvninger på en bestemt dato
        public List<Flight> GetFlightsByDate(DateTime date)
        {
            List<Flight> flightsOnDate = new List<Flight>();

            foreach (Flight flight in flights)
            {
                if (flight.Departure.Date == date.Date)
                {
                    flightsOnDate.Add(flight);
                }
            }

            return flightsOnDate;
        }

        // Gem valgte sæder
        public void SelectSeatsForFlight(Flight flight, List<Seat> selectedSeats)
        {
            foreach (Flight f in flights)
            {
                if (f.FlightId == flight.FlightId)
                {
                    foreach (Seat selected in selectedSeats)
                    {
                        foreach (Seat seat in f.Seats)
                        {
                            if (seat.SeatId == selected.SeatId)
                            {
                                seat.Passenger = selected.Passenger;
                            }
                        }
                    }
                }
            }
        }
    }
}