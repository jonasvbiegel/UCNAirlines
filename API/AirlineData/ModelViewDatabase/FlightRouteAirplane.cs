using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineData.ModelViewDatabase
{
    public class FlightRouteAirplane
    {
        public int FlightId { get; set; }        
        public DateTime Departure { get; set; }  
        public string AirplaneId { get; set; }    
        public string Airline { get; set; }      
        public int SeatRows { get; set; }        
        public int SeatColumns { get; set; }     
        public int FlightRouteId { get; set; }   

    }
}
