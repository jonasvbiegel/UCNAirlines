using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineData.ModelLayer
{
    public class Airport
    {
        public string? IcaoCode { get; set; }
        public string? AirportName { get; set; }
        public string? Zipcode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
