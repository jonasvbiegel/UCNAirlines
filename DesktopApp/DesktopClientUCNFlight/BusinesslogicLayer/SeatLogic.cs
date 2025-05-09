using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using DesktopClientUCNFlight.ServiceLayer;

namespace DesktopClientUCNFlight.BusinesslogicLayer
{
    public class SeatLogic
    {
        private ISeatAccess _seatServiceAccess;
        public SeatLogic()
        {
            _seatServiceAccess = new SeatServiceAccess();
        }
        public async Task<List<Seat>?> GetSeatsForFlight(int flightId)
        {
            List<Seat>? seats;
            try
            {
                seats = await _seatServiceAccess.GetSeats(flightId);
            }
            catch
            {
                seats = null;
            }

            return seats;
        }
        public async Task<bool> UpdateSeat(Seat seat)
        {
            try
            {
                return await _seatServiceAccess.UpdateSeat(seat);
            }
            catch
            {
                return false;
            }
        }
    }
}
