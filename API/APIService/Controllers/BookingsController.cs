using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using APIService.BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [Route("api/booking")]
    [ApiController]

    public class BookingController : ControllerBase
    {
        private readonly BookingDatabaseAccess _bookingDatabaseAccess = new();

        //public BookingController(BookingDatabaseAccess bookingDatabaseAccess)
        //{
        //    _bookingDatabaseAccess = bookingDatabaseAccess;
        //}

        // GET /api/bookings
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookings = _bookingDatabaseAccess.bookings.ToList();

            return Ok(bookings);
        }

        // GET /api/bookings/3
        [HttpGet("{bookingId}")]
        public IActionResult GetById([FromRoute] int bookingId)
        {
            var booking = _bookingDatabaseAccess.bookings.Find(booking => booking.BookingId == bookingId);

            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);    
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] Booking booking)
        {
            return Ok();
        }

        
        [HttpPut("{bookingId}")]
        public IActionResult Update([FromBody] Booking booking)
        {
            return Ok();

        }

        [HttpDelete("{bookingId}")]
        public void Delete(int bookingId)
        {

        }
    }

}
