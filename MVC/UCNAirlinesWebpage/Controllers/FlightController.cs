using Microsoft.AspNetCore.Mvc;
using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;

namespace UCNAirlinesWebpage.Controllers
{

    public class FlightController : Controller
    {
       
        [HttpGet]
        public IActionResult Index()
        {
            AirportServiceAccess ars = new AirportServiceAccess();

            List<string> airports = Task.Run(() => ars.GetAirports()).Result;
            AirportModel model = new()
            {
                Airports = airports
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Search(FlightSearchModel model)
        {
            return View(model);
        }


        public async  Task<IActionResult> SelectFlight(string from, string to, DateOnly date, int passenger)
        {
            var model = new FlightSearchModel
            {
                From = from,
                To = to,
                Date = date,
                Passenger = passenger
            };
            TempData["Passenger"] = passenger;
            FlightServiceAccess fac = new FlightServiceAccess();
            List<Flight> fls = await fac.GetFlights(date);
            model.Flights = new List<Flight>();
            foreach (Flight f in fls)
            {
                if (model.From == f.Route.StartDestination.AirportName && model.To == f.Route.EndDestination.AirportName)
                {
                    model.Flights.Add(f);
                }
            }
            //InsertData(model);

            return View(model);
        }
 
        //public void InsertData(FlightSearchModel model)
        //{
        //    model.Flights = new List<Flight>();

        //    Airplane airplane1 = new Airplane("NotBoeingA");
        //    Airplane airplane2 = new Airplane("NotBoeingB");

        //    Flightroute route1 = new Flightroute("Aalborg", "Nuuk");
        //    Flightroute route2 = new Flightroute("Aalborg", "Nuuk");

        //    DateTime departure1 = DateTime.Today.AddHours(10);
        //    DateTime departure2 = DateTime.Today.AddHours(22);

        //    DateTime departure3 = DateTime.Parse("02/05/2025 20:00");
        //    DateTime departure4 = DateTime.Parse("04/05/2025 20:00");   

        //    Flight flight1 = new Flight(1, route1, airplane1, departure4);
        //    Flight flight2 = new Flight(1, route2, airplane2, departure3);
        //    Flight flight3 = new Flight(1,route1, airplane1, departure1);
        //    Flight flight4 = new Flight(2, route2, airplane2, departure2);
        //    List<Flight> flights = new() { flight1, flight2, flight3, flight4 };

        //    //model.Flights.Add(flight1);
        //    //model.Flights.Add(flight2);

        //    model.Flights = flights.FindAll(f => DateOnly.FromDateTime(f.Departure)  == model.Date);
        //}

        public class BookingController : Controller
        {
            public IActionResult SelectSeat(FlightSearchModel model)
            {
                int passengers = model.Passenger;
                var newmodel = new BookingCreationModel
                {
                    Passengers = passengers,
                };
               

                return View(newmodel);
            }

        }

    }



   
}
