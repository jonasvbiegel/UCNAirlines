using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.ServiceLayer
{
    internal interface ISeatServiceAccess
    {
        Task<List<Seat>?> GetSeatsForFlight(int flightId);
        Task<bool> UpdateSeat(Seat seatToUpdate);

        Task<Seat> GetSeatBySeatID(int seatId);
    }
}
