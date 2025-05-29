using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UCNAirlinesWebpage.BusinesslogicLayer;
using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UCNAirlinesWebpage.Controllers
{
    public class FlightController : Controller
    {
        private AirportModel model;

        [HttpGet]
        public IActionResult Index()
        {
            AirportServiceAccess ars = new AirportServiceAccess();
            AirportModel model = new AirportModel()
            {
               Airports = Task.Run(() => ars.GetAirports()).Result
            };
            return View("Index", model);
        }
        

        public async Task<IActionResult> SelectFlight(string from, string to, DateOnly date, int passenger)
        {
            FlightLogic flightLogic = new FlightLogic();
            FlightSearchModel model1 = new FlightSearchModel();
            model1 = await flightLogic.ReturnSelectedFlightsAsync(from, to, date, passenger);
            if(model1.Flights.Count > 0)
            {
                return View(model1);

            }
            else
            {
                return Index();
            }
        }
       

    } 
}

    


