using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using Newtonsoft.Json;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public class SeatServiceAccess : ServiceConnection, ISeatServiceAccess
    {
        public SeatServiceAccess() : base("https://localhost:7184/api/seats/")
        { 
        }
        public async Task<List<Seat>?> GetSeatsForFlight(int flightId)
        {
            UseUrl = BaseUrl + "flightId?flightId=" + flightId;
            try
            {
                var response = await CallServiceGet();
                if (response != null && response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Seat>>(json);
                }
                else
                {
                    // Mulighed for fejlhåndtering baseret på HTTP-status
                    Console.WriteLine($"Fejl ved hentning af sæder. Status: {response?.StatusCode}");
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Netværksfejl ved hentning af sæder: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ukendt fejl i GetSeatsForFlightAsync: {ex.Message}");
            }

            return null;
        }
    }
}
