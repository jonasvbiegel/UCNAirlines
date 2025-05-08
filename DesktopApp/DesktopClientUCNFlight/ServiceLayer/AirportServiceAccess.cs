using Newtonsoft.Json;
using System.Net;
using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public class AirportServiceAccess : ServiceConnection, IAirportAccess
    {
        public AirportServiceAccess() : base("https://localhost:7184/api/airports/")
        {
        }

        public async Task<List<string>?> GetAirports()
        {
            List<string> airports = new List<string>();
            UseUrl = BaseUrl;

            var serviceResponse = await base.CallServiceGet();
            // if success (200-299)
            if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
            {
                if (serviceResponse.StatusCode == HttpStatusCode.OK)
                {
                    string responseData = await serviceResponse.Content.ReadAsStringAsync();
                    airports = JsonConvert.DeserializeObject<List<string>>(responseData);
                }
            }

            return airports; 
        }
    }
}
