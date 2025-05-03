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
        public List<Flight> GetFlightsByDate(DateTime date)
        {
            var allFlights = new List<Flight>();

            var airplane = new Airplane
            {
                AirplaneId = "ABC123",
                Airline = "UCN Airlines",
                SeatRows = 30,
                SeatColumns = 6
            };

            var airport1 = new Airport
            {
                IcaoCode = "DK123",
                AirportName = "Aalborg Airport",
                City = "Aalborg",
                Country = "Denmark"
            };

            var airport2 = new Airport
            {
                IcaoCode = "GL123",
                AirportName = "Nuuk Airport",
                City = "Nuuk",
                Country = "Greenland"
            };

            var route = new FlightRoute
            {
                FlightRouteId = 1,
                StartDestination = airport1,
                EndDestination = airport2
            };

            // Generér flyvninger for hele ugen
            DateTime startDate = new DateTime(2025, 6, 23);
            DateTime endDate = new DateTime(2025, 6, 28);

            for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {
                for (int i = 0; i < 3; i++)
                {
                    var departureTime = currentDate.Date.AddHours(8 + (i * 5)).AddMinutes(15 + (i * 30));

                    allFlights.Add(new Flight
                    {
                        FlightId = int.Parse($"{currentDate:yyyyMMdd}{i + 1}"),
                        Departure = departureTime,
                        Airplane = airplane,
                        Route = route,
                        Seats = new List<Seat>()
                    });
                }
            }

            // Filtrer flyvninger, så kun dem på den ønskede dato returneres
            return allFlights.Where(f => f.Departure.Date == date.Date).ToList();
        }
    }
}