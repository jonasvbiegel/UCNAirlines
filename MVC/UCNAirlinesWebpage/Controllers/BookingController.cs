using Microsoft.AspNetCore.Mvc;

namespace UCNAirlinesWebpage.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult SelectSeat()
        {
            return View();
        }
    }
}
