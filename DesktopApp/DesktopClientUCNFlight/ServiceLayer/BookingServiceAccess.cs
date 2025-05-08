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

        // Opretter bookingen baseret på sæder og tilknyttede passagerer
        public async Task<bool> CreateBooking(Flight flight, List<Seat> seats)
        {
            bool savedOk = false;

            try
            {
                // Opret en liste af passagerer og gem sæderne
                List<Passenger> passengers = new List<Passenger>();

                foreach (var seat in seats)
                {
                    if (seat.Passenger != null)
                    {
                        // Først opretter vi passageren
                        var passenger = seat.Passenger;

                        // Vi kalder metoden til at oprette passageren
                        bool passengerCreated = await CreatePassenger(passenger);

                        // Hvis passageren er oprettet, tilføjer vi til listen
                        if (passengerCreated)
                        {
                            passengers.Add(passenger);
                        }
                        else
                        {
                            Console.WriteLine($"Failed to create passenger for seat: {seat.SeatName}");
                            continue; // Hvis passageren ikke kunne oprettes, går vi videre
                        }
                    }
                }

                // Opret bookinganmodning med flight og passagerer
                var bookingRequest = new
                {
                    FlightId = flight.FlightId,
                    Passengers = passengers.Select(p => new
                    {
                        PassportNo = p.PassportNo,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        BirthDate = p.BirthDate.ToString("yyyy-MM-dd") // Konverter dato til korrekt format
                    }).ToList()
                };

                // Serialiser anmodningen til JSON
                var json = JsonConvert.SerializeObject(bookingRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Brug API URL til at sende POST-anmodningen
                UseUrl = BaseUrl + "booking"; // Sørg for, at denne URL er korrekt for dit API

                // Kalder API'en via baseklassen
                var serviceResponse = await CallServicePost(content);

                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    savedOk = true;
                }
            }
            catch (Exception ex)
            {
                // Hvis noget går galt, håndteres det her
                Console.WriteLine("Error creating booking: " + ex.Message);
                savedOk = false;
            }

            return savedOk;
        }

        // Opretter en passager
        private async Task<bool> CreatePassenger(Passenger passenger)
        {
            bool isPassengerCreated = false;

            try
            {
                // Opret passageranmodning
                var passengerRequest = new
                {
                    PassportNo = passenger.PassportNo,
                    FirstName = passenger.FirstName,
                    LastName = passenger.LastName,
                    BirthDate = passenger.BirthDate.ToString("yyyy-MM-dd")
                };

                // Serialiser passageranmodning til JSON
                var json = JsonConvert.SerializeObject(passengerRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send POST-anmodningen til passager API
                UseUrl = BaseUrl + "passenger"; // Sørg for, at denne URL er korrekt for dit API

                var serviceResponse = await CallServicePost(content); // Kalder API'en via baseklassen

                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    isPassengerCreated = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating passenger: " + ex.Message);
                isPassengerCreated = false;
            }

            return isPassengerCreated;
        }
    }
}