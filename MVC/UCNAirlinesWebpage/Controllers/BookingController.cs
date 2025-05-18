using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata;
using System.Xml.Linq;
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
            TempData["Flightid"]= flightId;
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
            FlightServiceAccess flightServiceAccess = new();
            SeatServiceAccess ssa = new();
            ReceiptModel model2 = new ReceiptModel();
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
                int flightId = (int)TempData["FlightId"];
                Flight f = Task.Run(() => flightServiceAccess.GetFlight(flightId)).Result;

                Booking book = InsertBooking(model.Passengers, f);
                model2.booking = book;
                
                passenger.seat = seat;
                
            }
            return View("TestWorld", model2);
        }
        public Booking InsertBooking(List<Passenger> passengers, Flight flight)
        {
            Booking booking = new Booking()
            {
                passengers = passengers,
                Flight = flight
            };
           BookingServiceAccess bsa = new BookingServiceAccess();
            bool bwa = bsa.InsertBooking(booking).Result;
            if (bwa == true)
            {
                return booking;
            }
            else
            {
                //throw new Exception(NoBooking);
                return null;
            }
        }
    }
}
