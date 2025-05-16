using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using DesktopClientUCNFlight.ServiceLayer;

namespace DesktopClientUCNFlight.BusinesslogicLayer
{
<<<<<<< HEAD
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
    }
}
