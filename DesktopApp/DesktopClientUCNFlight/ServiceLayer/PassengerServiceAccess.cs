
using Newtonsoft.Json;
using System.Net;
using System.Text;
using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public class PassengerServiceAccess : ServiceConnection, IPassengerAccess
    {
        public PassengerServiceAccess() : base("https://localhost:7184/api/passengers/")
        {
        }

        public async Task<Passenger> GetPassenger(string passportNo)
        {
            Passenger p = null;
            UseUrl = BaseUrl;
            UseUrl += passportNo;

            var serviceResponse = await base.CallServiceGet();
            // if success (200-299)
            if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
            {

                if (serviceResponse.StatusCode == HttpStatusCode.OK)
                {
                    string responseData = await serviceResponse.Content.ReadAsStringAsync();


                    p = JsonConvert.DeserializeObject<Passenger>(responseData);
                    

                }

            }
            return p;


        }
        public async Task<Passenger> InsertPassenger(Passenger passenger)
        {
            Passenger? p=null;
            UseUrl = BaseUrl;

            string passengerJson = JsonConvert.SerializeObject(passenger);
            var httpContent = new StringContent(passengerJson, Encoding.UTF8, "application/json");
            var serviceResponse = await base.CallServicePost(httpContent);

            if (serviceResponse.IsSuccessStatusCode)
            {
                p = passenger;
            }

            return p;

        }

    }
}
 
