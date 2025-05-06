using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;
using static System.Runtime.InteropServices.JavaScript.JSType;
using UCNAirlinesWebpage.ServiceLayer;

namespace UCNAirlinesWebpage.Controllers
{

    public class FlightController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SeatServiceAccess fac=new SeatServiceAccess();
            int id = 1;
            List<Seat> fls= await fac.GetSeats(1);
            
     
            return View(fls);
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
