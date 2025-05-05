using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public class BookingServiceAccess : IBookingServiceAccess
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7184/api/booking/";  // API URL

        public BookingServiceAccess()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> SaveBooking(Flight flight, List<Seat> seats)
        {
            var passengers = seats.Select(seat => new
            {
                FirstName = seat.Passenger.FirstName,
                LastName = seat.Passenger.LastName,
                PassportNo = seat.Passenger.PassportNo,
                BirthDate = seat.Passenger.BirthDate,
                SeatName = seat.SeatName
            });

            var bookingObject = new
            {
                FlightId = flight.FlightId,
                Passengers = passengers
            };

            var json = JsonConvert.SerializeObject(bookingObject);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Asynkron POST-anmodning til booking API
            var response = await _httpClient.PostAsync(_baseUrl, content);

            return response.IsSuccessStatusCode;
        }
    }
}