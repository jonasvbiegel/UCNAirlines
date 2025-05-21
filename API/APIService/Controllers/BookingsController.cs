using AirlineData.ModelLayer;
using APIService.BusinessLayer;
using APIService.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingLogic _bookingLogic;
        public BookingsController(IBookingLogic bookingLogic)
        {
            _bookingLogic = bookingLogic;
        }
        // POST api/<BookingsController>
        [HttpPost]
        public ActionResult<bool> PostBooking([FromBody] BookingDTO booking)
        {
            Console.WriteLine($"{booking.Flight.FlightId}");
            booking.Passengers.ForEach(f => Console.WriteLine(f.FirstName));

            bool b = false;

            try
            {

                b = _bookingLogic.CreateBooking(booking);
            }
            catch
            {
                return new StatusCodeResult(500);
            }

            return Ok(b);
        }
    }

}
