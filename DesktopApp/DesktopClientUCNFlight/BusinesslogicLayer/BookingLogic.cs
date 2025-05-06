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
        private readonly IBookingServiceAccess _bookingServiceAccess;

        public BookingLogic()
        {
            _bookingServiceAccess = new BookingServiceAccess();
        }

        public async Task<bool> SaveBooking(Flight flight, List<Seat> seats)
        {
            bool wasSaved;

            try
            {
                wasSaved = await _bookingServiceAccess.CreateBooking(flight, seats);
            }
            catch
            {
                wasSaved = false;
            }

            return wasSaved;

        }
    }
}