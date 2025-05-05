using Microsoft.AspNetCore.Mvc;
using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult SelectSeat(FlightSearchModel model, int SelectedFlight)
        {
            TempData["SelectedFlight"] = SelectedFlight;

            var newmodel = new BookingCreationModel
            {
            };


            return View(newmodel);
        }

    }
}
