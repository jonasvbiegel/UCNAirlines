using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        //private readonly IBookingLogic _businessLogicCtrl;

        public BookingController(IBookingLogic InbusinessLogicCtrl) {
            
            //_businessLogicCtrl = inBusinessLogicCtrl;
        }
        // POST api/<BookingController>
        [HttpPost]
        public ActionResult<BookingDTO> CreateBooking([FromBody] BookingDTO bookingDto)
        {
            try
            {
                BookingDTO newBooking = _businessLogicCtrl.CreateBooking(bookingDto);
                if (newBooking == null)
                {
                    return StatusCode(500, "Booking could not be created");
                }

                return Ok(newBooking);

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
