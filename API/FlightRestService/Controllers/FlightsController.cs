using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using FlightRestService.BusinessLogicLayer;
using FlightRestService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FlightRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightData _businessLogic;

        public FlightsController(IFlightData businessLogic)
        {
            _businessLogic = businessLogic;
        } 

        // GET: api/<FlightsController>
        [HttpGet]
        public ActionResult<List<FlightDTO>> GetAllFlights()
        {

            ActionResult<List<FlightDTO>> foundFlights;
            List<FlightDTO> flightsDto = _businessLogic.Get();
            if (flightsDto != null) 
            {
                if (flightsDto.Count > 0)
                {
                    foundFlights = Ok(flightsDto);
                }else 
                {
                    foundFlights = new StatusCodeResult(204);
                }
            }
            else
            {
                foundFlights = new StatusCodeResult(500);  
            }
            return foundFlights;
        }

        // GET api/<FlightsController>/5
        [HttpGet,Route("{id}")]
        public ActionResult<FlightDTO> Get(int id)
        {
            ActionResult<FlightDTO> foundFlight;
            FlightDTO flightDTO = _businessLogic.Get(id);
            if (flightDTO != null)
            {
                foundFlight = Ok(flightDTO);
            }
            else
            {
                foundFlight = new StatusCodeResult(500);
            }
                return foundFlight;
        }

    //    // POST api/<FlightsController>
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT api/<FlightsController>/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    // DELETE api/<FlightsController>/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    }
}
