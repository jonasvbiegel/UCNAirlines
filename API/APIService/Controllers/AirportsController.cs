using APIService.BusinessLayer;
using APIService.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportLogic _airportLogic;

        public AirportsController(IAirportLogic airportLogic)
        {
            _airportLogic = airportLogic;
        }

        [HttpGet]

        public ActionResult<List<string>> GetAllAirports()
        {

            ActionResult foundAirports;
            try
            {
                List<string?>? airports = _airportLogic.GetAllAirports();

                if (airports.Count > 0)
                {
                    foundAirports = Ok(airports);
                }
                else
                {
                    foundAirports = new StatusCodeResult(204);
                }
            }
            catch (SqlException)
            {
                {
                    foundAirports = StatusCode(500,"Something went wrong with retrieving airports");
                }
               
            }
            return foundAirports;
        }
    }
}
