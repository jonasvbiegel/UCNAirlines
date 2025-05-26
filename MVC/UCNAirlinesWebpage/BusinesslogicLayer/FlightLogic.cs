using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;

namespace UCNAirlinesWebpage.BusinesslogicLayer
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
    
    public async Task<Flight>? GetFlightById(int id)
        {
            Flight? foundFlight;
            try
            {
                foundFlight = await _flightServiceAccess.GetFlight(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving flights: {ex.Message}");
                foundFlight = null;
            }

            return foundFlight;
        }
    }
}

