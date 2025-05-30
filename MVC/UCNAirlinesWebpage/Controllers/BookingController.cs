using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using UCNAirlinesWebpage.BusinesslogicLayer;
using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.Controllers
{
    public class BookingController : Controller
    {
        private SeatPassengerModel model;

        public BookingController(){
            model = new ();
            }


        public async Task<IActionResult> GetSeats(int passenger, int flightId)
        {
            SeatLogic sl = new SeatLogic();
            model = await   sl.FindSeatAndFlight(passenger, flightId);
            TempData["FlightId"] = flightId;
            TempData["PassengerCount"] = passenger;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking()
        {
            BookingLogic bl = new BookingLogic();
            PassengerLogic pl = new PassengerLogic();
            ReceiptModel model2 = new ReceiptModel();
            int passengerCount = (int)TempData["PassengerCount"];
            List<Seat> seats = await pl.ConvertCookiesToPassengers(passengerCount, Request.Cookies);
            model2 = await bl.InsertBooking(seats, (int)TempData["FlightId"]);
            return View("TestWorld", model2);
        }
       
        
    }
}
