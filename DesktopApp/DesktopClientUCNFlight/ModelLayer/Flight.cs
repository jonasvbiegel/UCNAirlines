using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClientUCNFlight.ModelLayer
{
    public class Flight
    {
        public int FlightId { get; set; }
        
        public DateTime Departure_time_and_date { get; set; }
        public Airplane? Airplane { get; set; }
        public FlightRoute? Route { get; set; }
        public List<Seat?>? Seats { get; set; }
    }
}
