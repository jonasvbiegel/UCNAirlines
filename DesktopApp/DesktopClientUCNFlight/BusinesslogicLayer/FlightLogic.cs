using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using DesktopClientUCNFlight.ServiceLayer;

namespace DesktopClientUCNFlight.BusinesslogicLayer
{
        public class FlightLogic
        {
                private readonly IFlightAccess _flightServiceAccess;
                public FlightLogic()
                {
                        _flightServiceAccess = new FlightServiceAccess();
                }

                public async Task<List<Flight>?> GetFlightsByDate(string date)
                {
                        List<Flight>? foundFlights;
                        try
                        {
                                foundFlights = await _flightServiceAccess.GetFlights(date);
                        }
                        catch (Exception ex)
                        {
                                Console.WriteLine($"Error retrieving flights: {ex.Message}");
                                foundFlights = null;
                        }

                        return foundFlights;
                }
        }
}

