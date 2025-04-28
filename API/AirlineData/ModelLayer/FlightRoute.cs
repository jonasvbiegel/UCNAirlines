using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AirlineData.ModelLayer
{
    public class FlightRoute
    {
        public FlightRoute(Airport departure_airport, Airport arrival_airport)
        {
            Departure_airport = departure_airport;
            Arrival_airport = arrival_airport;
            
        }

        public FlightRoute(int flightRouteId, Airport departure_airport, Airport arrival_airport):this(departure_airport,arrival_airport)
        {
            FlightRouteId = flightRouteId;
            
        }
        [JsonIgnore]
        public int FlightRouteId { get; set; }
        public Airport Departure_airport { get; set; }//airport
        public Airport Arrival_airport { get; set; }//airport

        

        
    }
}
