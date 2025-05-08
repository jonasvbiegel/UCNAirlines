using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClientUCNFlight.ModelLayer
{
    public class Booking
    {
        public int BookingId { get; set; }
        public List<Passenger?>? Passengers { get; set; }
        public Flight? Flight { get; set; }
    }
}
