using Microsoft.AspNetCore.Mvc;
using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.Controllers
{
    public class BookingController : Controller
    {
        
        public IActionResult SelectSeat(FlightSearchModel model, int selectedFlight) {
        


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
