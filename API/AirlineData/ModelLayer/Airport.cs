using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineData.ModelLayer
{
    public class Airport
    {
        public Airport(string airportName, string code, string zipcode, string city, string country)
        {
            AirportName = airportName;
            Code = code;
            Zipcode = zipcode;
            City = city;
            Country = country;
        }

        public Airport(int airportId, string airportName, string code, string zipcode, string city, string country) : this(airportName,code,zipcode,city,country)
        {
            AirportId = airportId;
            
        }

        public int AirportId { get; set; }
        public string AirportName { get; set; }
        public  string Code { get; set; }    
        public string Zipcode { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
    
    
    }
}
