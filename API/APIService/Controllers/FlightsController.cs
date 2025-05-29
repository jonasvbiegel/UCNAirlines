using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using APIService.BusinessLayer;
using APIService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


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
            DateOnly dato = DateOnly.Parse(date);
            ActionResult<List<FlightDTO>> foundFlights;
            try
            {
                List<FlightDTO?>? flightsDto = _businessLogic.GetByDate(dato);
                if (flightsDto != null && flightsDto.Count > 0)
                {

                    foundFlights = Ok(flightsDto);
                }
                else
                {
                    foundFlights = new StatusCodeResult(204);
                }
            }
            catch (SqlException)
            {
                {
                    foundFlights = StatusCode(500,"Something went wrong with retrieving flights.");

                }
                
            }
            return foundFlights;
        }
        [HttpGet, Route("id")]
        public ActionResult<FlightDTO> GetFlightById(int id)
        {
            
            ActionResult<FlightDTO> foundFlight;
            try
            {
                FlightDTO? flightDto = _businessLogic.GetById(id);
                if (!(flightDto == null))
                {
                    foundFlight = Ok(flightDto);
                }

                else
                {
                    foundFlight = new StatusCodeResult(404);
                }
            }
            catch (SqlException)
            {
                foundFlight=StatusCode(500,"Something went wrong, couldn´t retrieve any flight with the specified id");
            }
            return foundFlight;
        }


    }
}
