using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Text;
using DesktopClientUCNFlight.ModelLayer;
using System;
using System.Net.Http;
using System.Configuration;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public class SeatServiceAccess : ServiceConnection, ISeatAccess
    {
        public SeatServiceAccess() : base(ConfigurationManager.AppSettings.Get("SeatUrl"))
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
        public async Task<bool> UpdateSeat(List<Seat> seat)
        {
            bool updated = false;
            UseUrl = BaseUrl;

            string seatJson = JsonConvert.SerializeObject(seat);
            var httpContent = new StringContent(seatJson, Encoding.UTF8, "application/json");
            var serviceResponse = await base.CallServicePut(httpContent);

            if (serviceResponse.IsSuccessStatusCode)
            {
                updated = true;
            }

            return updated;

        }
    }
}
