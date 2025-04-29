using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineData.ModelLayer
{
    public class Flight
    {
        public Flight(DateTime departure_time_and_date, Airplane airplane, FlightRoute route)
        {
            Departure_time_and_date = departure_time_and_date;
            Airplane1 = airplane;
            Route1 = route;
        }

        public int FlightId { get; set; }
        public DateTime Departure { get; set; }
        public Airplane? Airplane { get; set; }
        public FlightRoute? Route { get; set; }
        public DateTime Departure_time_and_date { get; }
        public Airplane Airplane1 { get; }
        public FlightRoute Route1 { get; }
    }
}
