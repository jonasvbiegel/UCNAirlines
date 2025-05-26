using AirlineData.ModelLayer;
using APIService.BusinessLayer;
using APIService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


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
            ActionResult postBooking;
            bool b = false;

            try
            {
                
                b = _bookingLogic.CreateBooking(booking);
                if (b)
                {
                    postBooking=Ok(b);
                }
                else
                {
                    postBooking = new StatusCodeResult(400);
                }
            }
            catch(SqlException)
            {
                return StatusCode(500,"Couldn´t save the booking, something went wrong.");
            }

            return Ok(b);
        }
    }

}
