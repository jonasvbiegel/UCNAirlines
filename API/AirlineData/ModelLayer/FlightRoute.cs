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
        public string DepartureAirport { get; set; }//airport
        public string ArrivalAirport { get; set; }//airport

        
    }
}
