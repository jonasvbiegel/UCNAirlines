 using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using UCNAirlinesWebpage.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UCNAirlinesWebpage.Controllers
{
    public class FlightController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Airplane airplane1 = new Airplane("NotBoeingA");
            Airplane airplane2 = new Airplane("NotBoeingB");

            Flightroute route1 = new Flightroute("Aalborg", "Nuuk");
            Flightroute route2 = new Flightroute("Aalborg", "Nuuk");

            DateTime departure1 = DateTime.Today.AddHours(10);
            DateTime departure2 = DateTime.Today.AddHours(22);


            List<Flight> flights = new List<Flight>
                {
                    new Flight(route1, airplane1,departure1),
                    new Flight(route2, airplane2, departure2)
                };
            
        
            return View();
        }

        [HttpPost]
        public IActionResult Search(FlightSearchModel model)
        {
            
         
            return View(model);
        }

        public IActionResult SelectFlight(string from, string to, string date, string passenger)
        {
            var model = new FlightSearchModel
            {
                From = from,
                To = to,
                Date = date,
                Passenger = passenger,

            };
            model.Flights = new List<Flight>();
            Airplane airplane1 = new Airplane("NotBoeingA");
            Airplane airplane2 = new Airplane("NotBoeingB");

            Flightroute route1 = new Flightroute("Aalborg", "Nuuk");
            Flightroute route2 = new Flightroute("Aalborg", "Nuuk");

            DateTime departure1 = DateTime.Today.AddHours(10);
            DateTime departure2 = DateTime.Today.AddHours(22);
            Flight flight1 = new Flight(route1, airplane1, departure1);
            Flight flight2 = new Flight(route2, airplane2, departure2);

            model.Flights.Add(flight1);
            model.Flights.Add(flight1);

            return View(model);
        }
        public IActionResult SelectSeat()
        {
            return View();
        }
        public void VerifyFlight(List<Flight> flights)
        {
            foreach (Flight flight in flights)
            {
                if (flight.Route.StartDestination == null || flight.Route.EndDestination == null)
                {
                    throw new NullRouteException();
                }
              

            }
         
           
        }


    }




    public class NullRouteException : Exception
    {
        public NullRouteException()
        {

        }
        public NullRouteException(string Message) : base(Message)
        {}
    }
}
