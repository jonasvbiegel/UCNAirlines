using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;

namespace UCNAirlinesWebpage.BusinesslogicLayer
{
    public class BookingLogic
    {
        private readonly IBookingAccess _bookingServiceAccess;

        public BookingLogic()
        {
            _bookingServiceAccess = new BookingServiceAccess();
        }

        public async Task<bool> SaveBooking(Booking b)
        {
            bool wasSaved = false;

            try
            {
                // Her vil du kalde på din service til at gemme bookingen
                wasSaved = await _bookingServiceAccess.InsertBooking(b);
            }
            catch (Exception ex)
            {
                // Hvis noget går galt, håndteres det her
                Console.WriteLine("Error saving booking: " + ex.Message);
                wasSaved = false;
            }

            return wasSaved;
        }
        public async Task<ReceiptModel> InsertBooking(List<Seat> seats, int flightId)
        {
            FlightLogic fl = new();
            Flight flight = await fl.GetFlightById(flightId);
            SeatLogic ssa = new();
            PassengerLogic psa = new();
            List<Passenger> passengers = new();
            ReceiptModel model = new ReceiptModel();
            foreach (Seat seat in seats)
            {
                passengers.Add(seat.Passenger);

            }
            if (passengers.Count > 0)
            {
                foreach (Passenger passenger in passengers)
                {
                    await psa.CreatePassenger(passenger);
                }
            }
            bool seatAdded = await ssa.UpdateSeats(seats);

            if (seatAdded)
            {
                Booking booking = new Booking()
                {
                    passengers = passengers,
                    Flight = flight
                };
                BookingLogic bsa = new BookingLogic();

                bool bookingCreated = await SaveBooking(booking);
                if (bookingCreated == true)
                {
                    model.Booking = booking;
                    return model;
                }
                else
                {
                    return null;
                }
            }
            else { return null; }
        }
    }
}
