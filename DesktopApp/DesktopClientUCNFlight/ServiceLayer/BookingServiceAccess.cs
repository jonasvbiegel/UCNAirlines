using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public class BookingServiceAccess : ServiceConnection, IBookingServiceAccess
    {
        public BookingServiceAccess() : base(ConfigurationManager.AppSettings.Get("ServiceUrlToUse"))
        {
        }
        public async Task<bool> CreateBooking(Flight flight, List<Passenger> passengers)
        {
            bool savedOk = false;

            // Opret bookinganmodning med flight og passagerer
            var bookingRequest = new
            {
                FlightId = flight.FlightId,
                Passengers = passengers.Select(p => new
                {
                    PassportNo = p.PassportNo,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    BirthDate = p.BirthDate.ToString("yyyy-MM-dd") // Konverterer dato til korrekt format
                }).ToList()
            };

            // Serialiser anmodningen til JSON
            var json = JsonConvert.SerializeObject(bookingRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Brug API URL til at sende POST-anmodningen
            UseUrl = BaseUrl + "booking";

            try
            {
                var serviceResponse = await CallServicePost(content);

                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    savedOk = true;
                }
            }
            catch
            {
                savedOk = false;
            }

            return savedOk;
        }
    }
}