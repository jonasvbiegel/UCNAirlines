using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineData.ModelViewDatabase
{
    public class RouteWithAirports
    {
        public int FlightRouteId { get; set; }
        public string StartAirportCode { get; set; }
        public string StartAirportName { get; set; }
        public string StartAirportZipCode { get; set; }
        public string StartAirportCity { get; set; }
        public string StartAirportCountry { get; set; }

        public string EndAirportCode { get; set; }
        public string EndAirportName { get; set; }
        public string EndAirportZipCode { get; set; }
        public string EndAirportCity { get; set; }
        public string EndAirportCountry { get; set; }
    }
}
