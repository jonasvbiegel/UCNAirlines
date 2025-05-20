using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Text.Json;
using UCNAirlinesWebpage.Models;
using System.Text;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

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
        public async Task<Seat?> GetSeatBySeatID(int seatId)
        {
            Seat seat = new Seat();
            UseUrl = UseUrl = $"{BaseUrl}seatId?seatId=";
            UseUrl += seatId;

            var serviceResponse = await base.CallServiceGet();
            // if success (200-299)
            if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
            {

                if (serviceResponse.StatusCode == HttpStatusCode.OK)
                {
                    string responseData = await serviceResponse.Content.ReadAsStringAsync();


                    seat = JsonConvert.DeserializeObject<Seat>(responseData);

                }

            }
            return seat;
        }

        public async Task<bool>? TryUpdateSeats(List<Seat?>? seats)
        {
            if (seats == null) return false;
            if (seats.Count == 0) return false;

            HttpClient client = new();
            string seatsJson = System.Text.Json.JsonSerializer.Serialize(seats);
            var httpContent = new StringContent(seatsJson, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(BaseUrl, httpContent);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                List<Seat?>? seatsReturn = System.Text.Json.JsonSerializer.Deserialize<List<Seat?>>(responseBody);
                if (seatsReturn != null) return seatsReturn.Count != 0;
            }

            return false;
        }
    }


}
