using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineData.ModelLayer
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime Departure { get; set; }
        public Airplane? Airplane { get; set; }
        public FlightRoute? Route { get; set; }
    }
}
