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
        public HttpStatusCode CurrentHttpStatusCode { get; private set; }
        public FlightServiceAccess() : base("https://localhost:7184/api/flights/")
        {
        }
        public async Task<List<Flight>?> GetFlightsByDate(DateOnly date)
        {
            List<Flight>? flightsFromService = null;

            UseUrl = BaseUrl + date.ToString("yyyy-MM-dd");

            try
            {
                var serviceResponse = await CallServiceGet();

                // Gem statuskode hvis nødvendigt
                CurrentHttpStatusCode = serviceResponse != null ? serviceResponse.StatusCode : HttpStatusCode.BadRequest;

                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    flightsFromService = JsonConvert.DeserializeObject<List<Flight>>(content);
                }
                else if (serviceResponse != null && serviceResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    flightsFromService = new List<Flight>();
                }
                else
                {
                    flightsFromService = null;
                }
            }
            catch
            {
                flightsFromService = null;
            }

            return flightsFromService;
        }
    }
}