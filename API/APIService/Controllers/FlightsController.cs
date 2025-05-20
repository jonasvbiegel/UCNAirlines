using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using APIService.BusinessLayer;
using APIService.DTOs;
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
        [HttpGet, Route("{date}")]
        public ActionResult<List<FlightDTO>> GetAllFlights(string date)
        {
            DateOnly dato=DateOnly.Parse(date);
            ActionResult<List<FlightDTO>> foundFlights;
            List<FlightDTO?>? flightsDto = _businessLogic.GetByDate(dato);
            if (!(flightsDto == null))
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
        [HttpGet, Route("id")]
        public ActionResult<FlightDTO> GetFlightById(int id)
        {
            
            ActionResult<FlightDTO> foundFlight;
            FlightDTO? flightDto = _businessLogic.GetById(id);
            if (!(flightDto == null))
            {
                    foundFlight = Ok(flightDto);
            }
            
            else
            {
                foundFlight= new StatusCodeResult(500);
            }
            return foundFlight;
        }


    }
}
