using System;
using UCNAirlinesWebpage.Models;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Net;
namespace UCNAirlinesWebpage.ServiceLayer
{
    public class FlightServiceAccess : ServiceConnection
    {
        public FlightServiceAccess() : base("https://localhost:7184/api/flights/")
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
                    foreach (var flight in flights.Take(1)) // Inspect the first flight
                    {
                        Console.WriteLine($"Flight Info: ID={flight.FlightId}, Date={flight.Departure}");
                    }

                }

            }
            return flights;


        }
    }
}
