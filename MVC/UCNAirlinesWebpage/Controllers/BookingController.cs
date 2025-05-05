using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCNAirlinesWebpage.Data;
using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.Controllers
{
    public class BookingController : Controller
    {
        // GET: BookingController
        public ActionResult Index(int id)
        {    
            FlightData flightData = new FlightData();
            Flight flight = flightData.GetById(id);
            TempData["Passenger"] = "3";
            // Retrieve passenger count from TempData
            string? passengerCountString = TempData["Passenger"] as string;
            int passengerCount = 0;

            if (!string.IsNullOrEmpty(passengerCountString) && int.TryParse(passengerCountString, out int parsedCount))
            {
                passengerCount = parsedCount;
            }

            // Initialize passengers list for the booking
            List<Passenger> passengers = new List<Passenger>();

            // Create booking object
            Booking booking = new Booking
            {
                Passengers = passengers,
                Flight = flight
            };

            // Pass the booking object to the view
            return View(booking);
        }

        // GET: BookingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
