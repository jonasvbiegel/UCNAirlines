using Microsoft.AspNetCore.Mvc;
using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.Controllers
{
    public class BookingController : Controller
    {
        [HttpPost]
        public IActionResult SetPassengerInfo(int passenger)
        {
            HttpContext.Session.SetInt32("PassengerTarget", passenger);

            return RedirectToAction("Create", "Passenger");
        }
        
        public IActionResult SelectSeat(FlightSearchModel model, int selectedFlight) 
        {
          
            var newmodel = new BookingCreationModel
            {
                SelectedFlight = selectedFlight,
                Passengers = (int)TempData["Passenger"],
            };
            TempData.Keep("Passenger");
            return View(newmodel);
        }
    }
}
