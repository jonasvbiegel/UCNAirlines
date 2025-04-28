using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineData.ModelLayer
{
    public class FlightRoute
    {
        public int FlightRouteId { get; set; }
        public Airport? StartDestination { get; set; }
        public Airport? EndDestination { get; set; }
    }
}
