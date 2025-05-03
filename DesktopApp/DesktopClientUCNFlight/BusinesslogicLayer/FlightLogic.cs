using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using DesktopClientUCNFlight.ServiceLayer;

namespace DesktopClientUCNFlight.BusinesslogicLayer
{
    public class FlightLogic
    {
        private readonly IFlightServiceAccess _flightServiceAccess;
        public FlightLogic()
        {
            _flightServiceAccess = new FlightServiceAccess();
        }

        public List<Flight> GetFlightsByDate(DateTime date)
        {
            return _flightServiceAccess.GetFlightsByDate(date);
        }

        public void SelectSeatsForFlight(Flight flight, List<Seat> seats)
        { 
            
        }
    }
}
