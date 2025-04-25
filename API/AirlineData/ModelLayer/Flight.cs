using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineData.ModelLayer
{
    //Skal man have DTO HER, har vi lyst til at vise alle seats eller bare de der er til rådighed
    //Skal man i stedet for airplane informationerne bare have airplane navn som string i DTO
    
    public class Flight
    {
        public Flight(DateTime departure, Airplane airplane, FlightRoute route)
        {
            Departure = departure;
            ListOfSeats = new List<Seat>();
            this.Airplane = airplane;
            this.Route = route;
        }

        public Flight(int flightId, DateTime departure, Airplane airplane, FlightRoute route): this(departure,airplane,route)
        {
            FlightId = flightId;
            
        }

        public int FlightId { get; set; }
        public DateTime Departure { get; set; }
        public List<Seat> ListOfSeats { get; set; }
        public Airplane Airplane { get; set; }
        public FlightRoute Route {get; set; }

    }
}
