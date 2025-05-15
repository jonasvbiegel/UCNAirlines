using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClientUCNFlight.ModelLayer
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string? SeatName { get; set; }
        public Passenger? Passenger { get; set; }
    }
}
