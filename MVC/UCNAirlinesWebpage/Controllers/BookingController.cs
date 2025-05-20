using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;

namespace UCNAirlinesWebpage.Controllers
{
    public class BookingController : Controller
    {



        public IActionResult GetSeats(int passenger, int flightId)
        {
            SeatServiceAccess ssa = new SeatServiceAccess();
            TempData["FlightId"] = flightId;
            TempData["PassengerCount"] = passenger;
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
        public  async Task<IActionResult> CreateBooking(SeatPassenger model)
        {
            model.Passengers = new();
            FlightServiceAccess flightServiceAccess = new();
            SeatServiceAccess ssa = new();
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
                Seat seat = await ssa.GetSeatBySeatID(seatId);
                seat.Passenger = passenger;
                model.Seats.Add(seat);
            }
            int flightId = (int)TempData["FlightId"];
            Flight f = await flightServiceAccess.GetFlight(flightId);

            model2.booking = await InsertBooking(model.Seats, f);
            return View("TestWorld", model2);
        }
        public async Task<Booking> InsertBooking(List<Seat> seats, Flight flight)
        {
            SeatServiceAccess ssa = new();
            PassengerServiceAccess psa = new();
           
            List<Passenger> passengers = new();
            foreach (Seat seat in seats)
            {
                passengers.Add(seat.Passenger);
                
            }
            if (passengers.Count > 0)
            {
                foreach (Passenger passenger in passengers)
                {
                    psa.InsertPassenger(passenger);
                }
            }
            bool seatAdded = await ssa.TryUpdateSeats(seats);

            if (seatAdded)
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
            return null;
        }
    }
}
