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
        public string StartZipCode { get; set; }      
        public string EndAirportCode { get; set; }    
        public string EndAirportName { get; set; }    
        public string EndZipCode { get; set; }        

    }
}
