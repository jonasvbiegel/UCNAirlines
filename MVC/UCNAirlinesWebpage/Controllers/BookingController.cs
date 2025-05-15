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

        
      
        public IActionResult GetSeats(int passenger, int flightId)
        {
            SeatServiceAccess ssa = new SeatServiceAccess();
            FlightServiceAccess flightServiceAccess = new FlightServiceAccess();
            List<Seat> seats = Task.Run(() => ssa.GetSeats(flightId)).Result;
            Flight f = Task.Run(() => flightServiceAccess.GetFlight(flightId)).Result;
            List<Passenger> passengersList = new List<Passenger>();
            SeatPassenger sp = new()
            {
                Flight = f,
                passengerCount = passenger,
                Passengers = passengersList,
                Seats = seats
            };

            return View(sp);
        }
        [HttpPost]
        public IActionResult CreateBooking(SeatPassenger model)
        {
            model.Passengers = new();
            SeatServiceAccess ssa = new();
           
            for (int i = 0; i < 4; i++)
            {
                string SDate = Request.Cookies[i + "Birthdate"];
                DateOnly date = DateOnly.Parse(SDate);
                Passenger passenger = new()
                {
                    FirstName = Request.Cookies[i + "FirstName"],
                    LastName = Request.Cookies[i + "LastName"],
                    PassportNo = Request.Cookies[i + "PassportNr"],
                    BirthDate = date

                };
                int seatId = Int32.Parse(Request.Cookies[i + "SeatId"]);
                model.Passengers.Add(passenger);
                Seat seat = Task.Run(() => ssa.GetSeatBySeatID(seatId)).Result;
                passenger.seat = seat;                
            }


            

            return View("TestWorld",model);
        }



    }
}
