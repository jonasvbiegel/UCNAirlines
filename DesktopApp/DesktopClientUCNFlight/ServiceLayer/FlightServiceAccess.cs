using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using Newtonsoft.Json;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public class FlightServiceAccess : ServiceConnection, IFlightServiceAccess
    {
        public FlightServiceAccess() : base("https://localhost:7184/api/flights/")
        {
        }
        public async Task<List<Flight>?> GetFlightsByDate(DateOnly date)
        {
            List<Flight>? flightsFromService = null;

            UseUrl = BaseUrl + date.ToString();

            try
            {
                var serviceResponse = await CallServiceGet();

                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    flightsFromService = JsonConvert.DeserializeObject<List<Flight>>(content);
                }
                else if (serviceResponse != null && serviceResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    flightsFromService = new List<Flight>(); // Ingen fly fundet
                }
                else
                {
                    flightsFromService = null; // Anden fejl
                }
            }
            catch
            {
                flightsFromService = null; // Exception, fx netværksfejl
            }

            return flightsFromService;
        }
    }
}