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



        public async Task<IActionResult> GetSeats(int passenger, int flightId)
        {
            SeatLogic ssa = new SeatLogic();
            TempData["FlightId"] = flightId;
            TempData["PassengerCount"] = passenger;
            FlightLogic flightServiceAccess = new FlightLogic();
            List<Seat> seats = Task.Run(() => ssa.GetSeatsForFlight(flightId)).Result;
            Flight f = await flightServiceAccess.GetFlightById(flightId);
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
        public async Task<IActionResult> CreateBooking(SeatPassenger model)
        {
            model.Passengers = new();
            FlightLogic flightServiceAccess = new();
            SeatLogic ssa = new();
            ReceiptModel model2 = new ReceiptModel();
            model.Seats = new();
            int passengerCount = (int)TempData["PassengerCount"];
            for (int i = 0; i < passengerCount; i++)
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

                int seatId = Convert.ToInt32(Request.Cookies[i + "SeatId"]);
                model.Passengers.Add(passenger);
                Seat seat = await ssa.GetSeatBySeatId(seatId);
                seat.Passenger = passenger;
                model.Seats.Add(seat);
            }
            int flightId = (int)TempData["FlightId"];
            Flight f = await flightServiceAccess.GetFlightById(flightId);

            model2.booking = await InsertBooking(model.Seats, f);
            return View("TestWorld", model2);
        }
        public async Task<Booking> InsertBooking(List<Seat> seats, Flight flight)
        {
            SeatLogic ssa = new();
            PassengerLogic psa = new();

            List<Passenger> passengers = new();
            foreach (Seat seat in seats)
            {
                passengers.Add(seat.Passenger);

            }
            if (passengers.Count > 0)
            {
                foreach (Passenger passenger in passengers)
                {
                   await psa.CreatePassenger(passenger);
                }
            }
            bool seatAdded = await ssa.UpdateSeats(seats);

            if (seatAdded)
            {
                Booking booking = new Booking()
                {
                    passengers = passengers,
                    Flight = flight
                };
                BookingLogic bsa = new BookingLogic();

                bool bwa = await bsa.SaveBooking(booking);
                if (bwa == true)
                {

                    return booking;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
