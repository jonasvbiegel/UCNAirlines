using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineData.ModelLayer
{
    public class PassengerBooking
    {
        public int BoolingId { get; set; }
        public Booking? Booking { get; set; }

        public int PassportNo { get; set; }
        public Passenger? Passenger { get; set; }

    }
}
