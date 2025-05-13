using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;

namespace UCNAirlinesWebpage.Controllers
{
    public class BookingController : Controller
    {

        public IActionResult Pain()
        {

            Console.WriteLine("Hello World!");

            return View("TestWorld");
        }
        public IActionResult SelectSeat(FlightSearchModel model, Flight SelectedFlight)
        {



            var newmodel = new BookingCreationModel
            {
                Flight = SelectedFlight,
                Passengers = (int)TempData["Passenger"],
            };
            //List<Flight> flights = TempData["flights"] as List<Flight>;
            //foreach (Flight f in flights)
            //{
            //    if (f.FlightId.Equals(selectedFlight))
            //    {
            //        newmodel.Flight = f;
            //    }

            TempData.Keep("Passenger");

            return View(newmodel);
        }
        public IActionResult GetSeats(int passenger, int flightId)
        {
            SeatServiceAccess ssa = new SeatServiceAccess();
            List<Seat> seats = Task.Run(() => ssa.GetSeats(flightId)).Result;
            List<Passenger> passengersList = new List<Passenger>();
            Flight f = new()
            {
                FlightId = flightId
            };
            SeatPassenger sp = new()
            {
                Flight = f,
                passengerCount = passenger,
                Passengers = passengersList,
                Seats = seats,
                Pass = Request.Cookies["0FirstName"]
            };

            System.Diagnostics.Debug.WriteLine(sp.Pass); 

            return View(sp);
        }
        [HttpPost]
        public IActionResult CreateBooking(SeatPassenger model)
        {
            model.Passengers = new();
           
            for (int i = 0; i < model.passengerCount; i++)
            {
                Passenger p = new()
                {
                    FirstName = Request.Cookies[i + "FirstName"],
                    LastName = Request.Cookies[i + "LastName"]
                };
                model.Passengers.Add(p);
                 Seat s = new()
                {
                     Passenger = p,
                     SeatId = Request.Cookies[i+ "SeatId"]
                };
            }

                
            return View(model);
        }



    }
}
