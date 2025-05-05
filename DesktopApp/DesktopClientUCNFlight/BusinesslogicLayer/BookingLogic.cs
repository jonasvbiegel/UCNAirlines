using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using DesktopClientUCNFlight.ServiceLayer;

namespace DesktopClientUCNFlight.BusinesslogicLayer
{
    public class BookingLogic
    {
        private readonly IPassengerServiceAccess _passengerServiceAccess;
        private readonly IBookingServiceAccess _bookingServiceAccess;

        public BookingLogic()
        {
            _passengerServiceAccess = new PassengerServiceAccess();
            _bookingServiceAccess = new BookingServiceAccess();
        }

        public async Task<bool> SaveBooking(Flight flight, List<Seat> seats)
        {
            // Opret passagerer ved at kalde PassengerServiceAccess
            List<Passenger> createdPassengers = new List<Passenger>();

            foreach (var seat in seats)
            {
                var passenger = seat.Passenger;
                var createdPassenger = await _passengerServiceAccess.PostPassenger(passenger);

                if (createdPassenger == null)
                {
                    // Hvis oprettelsen af passageren fejler
                    return false;
                }

                // Tilføj den oprettede passager til listen
                createdPassengers.Add(createdPassenger);

                // opdatere seat med den oprettede passager, hvis nødvendigt
                seat.Passenger = createdPassenger;
            }

            // Når alle passagerer er oprettet, kan vi gemme bookingen
            bool bookingSaved = await _bookingServiceAccess.SaveBooking(flight, seats);

            // Returner om bookingen blev gemt korrekt
            return bookingSaved;
        }
    }
}