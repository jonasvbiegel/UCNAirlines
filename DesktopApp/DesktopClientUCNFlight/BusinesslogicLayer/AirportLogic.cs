using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ServiceLayer;

namespace DesktopClientUCNFlight.BusinesslogicLayer
{
    public class AirportLogic
    {
        private readonly IAirportAccess _airportServiceAccess;

        public AirportLogic()
        {
            _airportServiceAccess = new AirportServiceAccess();
        }
        public async Task<List<string>?> GetAirports()
        {
            List<string>? foundAirports;
            try
            {
                foundAirports = await _airportServiceAccess.GetAirports();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving airports: {ex.Message}");
                foundAirports = null;
            }

            return foundAirports;
        }
    }
}
