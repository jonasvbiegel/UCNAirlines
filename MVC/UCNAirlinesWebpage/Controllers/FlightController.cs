 using System.Linq.Expressions;
using System.Reflection;
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
            
        // List <Flight> getSortedFlight(DateTime Departuretime)
            return View();
        }

        [HttpPost]
        public IActionResult Search(FlightSearchModel model)
        {
            return View(model);
        }

        public IActionResult SelectFlight(string from, string to, DateOnly date, string passenger)
        {
            var model = new FlightSearchModel
            {
                From = from,
                To = to,
                Date = date,
                Passenger = passenger
            };
            InsertData(model);

            return View(model);
        }
        public IActionResult SelectSeat()
        {
            return View();
        }
        public void InsertData(FlightSearchModel model)
        {
            model.Flights = new List<Flight>();

            Airplane airplane1 = new Airplane("NotBoeingA");
            Airplane airplane2 = new Airplane("NotBoeingB");

            Flightroute route1 = new Flightroute("Aalborg", "Nuuk");
            Flightroute route2 = new Flightroute("Aalborg", "Nuuk");

            DateTime departure1 = DateTime.Today.AddHours(10);
            DateTime departure2 = DateTime.Today.AddHours(22);

            DateTime departure3 = DateTime.Parse("02/05/2025 20:00");
            DateTime departure4 = DateTime.Parse("04/05/2025 20:00");   

            Flight flight1 = new Flight(route1, airplane1, departure4);
            Flight flight2 = new Flight(route2, airplane2, departure3);
            List<Flight> flights = new() { flight1, flight2 };
            //model.Flights.Add(flight1);
            //model.Flights.Add(flight2);

            model.Flights = flights.FindAll(f => DateOnly.FromDateTime(f.Departure) == model.Date);
        }
      
       

    }



   
}
