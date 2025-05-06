using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using UCNAirlinesWebpage.Models;
using System.Text;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace UCNAirlinesWebpage.ServiceLayer
{
    public class SeatServiceAccess : ServiceConnection, ISeatAccess
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
        public async Task<bool> UpdateSeat(Seat seat)
        {
            bool updated = false;
            UseUrl = BaseUrl;

            string seatJson=JsonConvert.SerializeObject(seat);
            var httpContent = new StringContent(seatJson, Encoding.UTF8, "application/json");
            var serviceResponse = await base.CallServicePut(httpContent);

            if (serviceResponse.IsSuccessStatusCode)
            {
                updated = true;
            }

            return updated;

        }
    }
//     public async Task<int> SavePerson(Person personToSave)
//        {
//            int insertedPersonId = -1;

//            UseUrl = BaseUrl;
//            try
//            {
//                string personJson = JsonConvert.SerializeObject(personToSave);
//                var httpContent = new StringContent(personJson, Encoding.UTF8, "application/json");
//                // Call service
//                var serviceResponse = await base.CallServicePost(httpContent);
//                // If success 200-299
//                if (serviceResponse is not null && serviceResponse.IsSuccessStatusCode)
//                {
//                    string idString = await serviceResponse.Content.ReadAsStringAsync();
//                    bool idNumOk = int.TryParse(idString, out insertedPersonId);
//                    if (!idNumOk)
//                    {
//                        insertedPersonId = -2;
//                    }
//                }
//            }
//            catch
//            {
//                insertedPersonId = -3;
//            }
//            return insertedPersonId;
//        }
//    }
//}

}
