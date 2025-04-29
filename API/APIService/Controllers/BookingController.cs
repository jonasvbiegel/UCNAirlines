using APIService.BusinessLogicLayer;
using APIService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IBookingLogic _businessLogicCtrl;

        public BookingController(IBookingLogic InBusinessLogicCtrl) {

            _businessLogicCtrl = InBusinessLogicCtrl;
        }

        // POST api/<BookingController>
        [HttpPost]
        public ActionResult<int> CreateBooking(BookingDTO bookingDto)
        {
            try
            {
                int newBooking = _businessLogicCtrl.CreateBooking(bookingDto);
                if (newBooking > 0)
                {
                    return Ok(newBooking);
                }
                else
                {
                    return StatusCode(500, "Booking could not be created");
                }
            } catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
