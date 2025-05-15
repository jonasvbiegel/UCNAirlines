using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.ServiceLayer
{
    public class SeatServiceAccess : ServiceConnection
    {
        public SeatServiceAccess() : base("https://localhost:7184/api/seats/")
        {   
        }
        public async Task<List<Seat>?> GetSeats(int flightId)
        {
            List<Seat> seats = new List<Seat>();
            UseUrl = UseUrl = $"{BaseUrl}flightId?flightId=";
            UseUrl += flightId;

            var serviceResponse = await base.CallServiceGet();
            // if success (200-299)
            if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
            {

                if (serviceResponse.StatusCode == HttpStatusCode.OK)
                {
                    string responseData = await serviceResponse.Content.ReadAsStringAsync();


                    seats = JsonConvert.DeserializeObject<List<Seat>>(responseData);

                }


            }
            return seats;


        }
    }
}
