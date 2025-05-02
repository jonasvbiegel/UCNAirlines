using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using APIService.BusinessLogicLayer;
using APIService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        [HttpGet,Route("{dateAndTime}")]
        public ActionResult<List<FlightDTO>> GetAllFlights(DateTime dateAndTime)
        {

            ActionResult<List<FlightDTO>> foundFlights;
            List<FlightDTO?>? flightsDto = _businessLogic.GetByDateAndTime(dateAndTime);
            if (!(flightsDto==null))
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

        
    }
}
