using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using Newtonsoft.Json;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public class PassengerServiceAccess : ServiceConnection, IPassengerServiceAccess
    {
        public PassengerServiceAccess() : base(ConfigurationManager.AppSettings.Get("ServiceUrlToUse"))
        {
        }

        // Asynkron metode til at oprette en passager
        public async Task<Passenger?> PostPassenger(Passenger passenger)
        {
            int newPassengerId = null;
            UseUrl = BaseUrl + "passenger";

            try
            {
                var json = JsonConvert.SerializeObject(passenger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var serviceResponse = await CallServicePost(content);
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var responseContent = await serviceResponse.Content.ReadAsStringAsync();
                    newPassengerId = JsonConvert.DeserializeObject<int>(responseContent);
                }
            }
            catch
            {
                newPassengerId = null;
            }

            return newPassengerId;
        }
    }
}