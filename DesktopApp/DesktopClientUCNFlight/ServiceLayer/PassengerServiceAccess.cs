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
        public PassengerServiceAccess() : base("https://localhost:7184/api/airports/")
        {
        }

        // Asynchronous method to create a passenger
        public async Task<Passenger?> PostPassenger(Passenger passenger)
        {
            Passenger? newPassenger = null; // Change from int to Passenger
            UseUrl = BaseUrl + "passenger";

            try
            {
                var json = JsonConvert.SerializeObject(passenger);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var serviceResponse = await CallServicePost(content);
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var responseContent = await serviceResponse.Content.ReadAsStringAsync();
                    newPassenger = JsonConvert.DeserializeObject<Passenger>(responseContent); // Deserialize to Passenger
                }
            }
            catch
            {
                newPassenger = null; // Return null in case of an error
            }

            return newPassenger; // Return the Passenger object
        }
    }
}