using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public interface IBookingServiceAccess
    {
        Task<bool> SaveBooking(Flight flight, List<Seat> seats);
    }
}
