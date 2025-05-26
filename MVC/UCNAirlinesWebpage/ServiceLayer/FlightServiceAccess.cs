using System;
using UCNAirlinesWebpage.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Net;
using UCNAirlinesWebpage.Helper;
namespace UCNAirlinesWebpage.ServiceLayer
{
    public class FlightServiceAccess : ServiceConnection,IFlightAccess
    {
        public FlightServiceAccess() : base(ConfigHelper.Configuration?["ServiceUrls:Flights"])
        {
        }
        public async Task<List<Flight>?> GetFlights(string date)
        {
            List<Flight> flights = new List<Flight>();
            UseUrl = BaseUrl;
            UseUrl += date;

            var serviceResponse = await base.CallServiceGet();
            // if success (200-299)
            if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
            {

                if (serviceResponse.StatusCode == HttpStatusCode.OK)
                {
                    string responseData = await serviceResponse.Content.ReadAsStringAsync();


                    flights = JsonConvert.DeserializeObject<List<Flight>>(responseData);


                }

            }
            return flights;
        }
        public async Task<Flight?> GetFlight(int flightId)
        {
            Flight flight = null;
            UseUrl = UseUrl = $"{BaseUrl}id?id=";
            UseUrl += flightId;

            var serviceResponse = await base.CallServiceGet();
            // if success (200-299)
            if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
            {

                if (serviceResponse.StatusCode == HttpStatusCode.OK)
                {
                    string responseData = await serviceResponse.Content.ReadAsStringAsync();


                    flight = JsonConvert.DeserializeObject<Flight>(responseData);

                }


            }
            return flight;


        }
    }
}
