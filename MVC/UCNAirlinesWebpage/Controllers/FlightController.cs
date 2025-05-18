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


        public async Task<IActionResult> SelectFlight(string from, string to, DateOnly date, int passenger)
        {
            var model = new FlightSearchModel
            {
                From = from,
                To = to,
                Date = date,
                Passenger = passenger
            };
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

            return View(model);
        }
       

    } 
}
