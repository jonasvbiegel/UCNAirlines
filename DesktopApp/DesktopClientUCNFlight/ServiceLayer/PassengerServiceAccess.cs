using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using Newtonsoft.Json;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public class PassengerServiceAccess : IPassengerServiceAccess
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7184/api/passengers/";  // API URL

        public PassengerServiceAccess()
        {
            _httpClient = new HttpClient();
        }

        // Asynkron metode til at oprette en passager
        public async Task<Passenger> PostPassenger(Passenger passenger)
        {
            var json = JsonConvert.SerializeObject(passenger);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Asynkron POST-anmodning til API
            var response = await _httpClient.PostAsync(_baseUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Passenger>(result);
            }
            else
            {
                // Hvis noget går galt, returneres null
                return null;
            }
        }
    }
}