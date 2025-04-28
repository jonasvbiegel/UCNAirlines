using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.Controllers
{
    public class FlightController : Controller
    {
        

        public IActionResult Index()
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
