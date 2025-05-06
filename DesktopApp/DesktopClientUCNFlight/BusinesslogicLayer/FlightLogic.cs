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
        private readonly IFlightServiceAccess _flightServiceAccess;
        public FlightLogic()
        {
            _flightServiceAccess = new FlightServiceAccess();
        }

        public async Task<List<Flight>?> GetFlightsByDate(DateOnly date)
        {
            List<Flight>? foundFlights;
            try
            {
                foundFlights = await _flightServiceAccess.GetFlightsByDate(date);
            }
            catch
            {
                foundFlights = null;
            }

            return foundFlights;
        }
    }
}

