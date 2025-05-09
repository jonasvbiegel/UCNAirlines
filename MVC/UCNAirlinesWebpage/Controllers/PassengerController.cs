using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.Controllers
{
    public class PassengerController : Controller
    {

        private static List<Passenger> _passengerList = new List<Passenger>();

        public static int CurrentCount => _passengerList.Count;

        [HttpGet]
        public IActionResult Create()
        {
            int? target = HttpContext.Session.GetInt32("PassengerTarget");
            if (target == null) return RedirectToAction("Index", "Booking");

            if (_passengerList.Count >= target)
            {
                return RedirectToAction("List");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Passenger passenger)
        {
            int? target = HttpContext.Session.GetInt32("PassengerTarget");
            if (target == null) return RedirectToAction("Index", "Booking");

            if (ModelState.IsValid)
            {
                if(_passengerList.Count < target)
                {
                    _passengerList.Add(passenger);
                }

                if (_passengerList.Count >= target)
                {
                    return RedirectToAction("List");
                }
                return RedirectToAction("Create");
            }
            return View(passenger);
        }

        public IActionResult List()
        {
            return View(_passengerList);
        }
    }

}
