using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using APIService.BusinessLogicLayer;
using APIService.DTOs;
using APIService.ModelConversion;
using Microsoft.AspNetCore.Mvc;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightLogic _businessLogic;

        public FlightsController(IFlightLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        // GET: api/<FlightsController>
        [HttpGet, Route("GetAllFlightsByDate")]
        public ActionResult<List<FlightDTO>> GetAllFlights([FromQuery] DateTime date)
        {

            ActionResult<List<FlightDTO>> foundFlights;
            List<FlightDTO> flightsDto = _businessLogic.Get(date);
            if (flightsDto != null)
            {
                if (flightsDto.Count > 0)
                {
                    foundFlights = Ok(flightsDto);
                }
                else
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
        [HttpGet, Route("{id}")]
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
                foundFlight = new StatusCodeResult(404);
            }
            return foundFlight;
        }

        //Kun STAFF/Admin kan oprette nye flyvninger
        // POST api/<FlightsController>
        [HttpPost, Route("flights")]
        public ActionResult<int> PostNewFlight(FlightDTO newFlight)
        {
            ActionResult<int> foundFlight;
            int insertedFlight = -1;
            if (newFlight != null)
            {
                insertedFlight = _businessLogic.Create(newFlight);
            }

            //Evaluate
            if (insertedFlight > 0)
            {
                foundFlight = Ok(insertedFlight);
            }
            else if (insertedFlight == 0)
            {
                foundFlight = BadRequest();  // missing input
            }
            else
            {
                foundFlight = new StatusCodeResult(500); // Internal server error
            }
            return foundFlight;
        }

    }
}
