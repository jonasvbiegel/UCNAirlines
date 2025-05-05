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
        private ISeatServiceAccess _seatServiceAccess;
        public SeatLogic()
        {
            _seatServiceAccess = new SeatServiceAccess();
        }
        public async Task<List<Seat>?> GetSeatsForFlight(int flightId)
        {
            // Kalder servicen for at hente sæderne
            return await _seatServiceAccess.GetSeatsForFlight(flightId);
        }
    }
}
