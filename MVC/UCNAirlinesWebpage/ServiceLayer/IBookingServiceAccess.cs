using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.ServiceLayer
{
    public interface IBookingServiceAccess
    {
        Task<bool> CreateBooking(Flight flight, List<Seat> seats);
    }
}
