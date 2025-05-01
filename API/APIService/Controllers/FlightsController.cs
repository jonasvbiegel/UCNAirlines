using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private FlightDatabaseAccess flightDatabaseAccess;

        // GET: api/<FlightsController>
        [HttpGet]
        public ActionResult<List<Flight>> GetAllFlights()
        {
            flightDatabaseAccess = new FlightDatabaseAccess();
            var flights = flightDatabaseAccess.GetFlight_s();
            return Ok(flights);
        }

        // GET api/<FlightsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FlightsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FlightsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlightsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
