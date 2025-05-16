using APIService.BusinessLayer;
using APIService.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            
            ActionResult<List<string>> foundAirports;
            List<string?>? airports = _airportLogic.GetAllAirports();
            if (!(airports == null))
            {
                if (airports.Count > 0)
                {
                    foundAirports = Ok(airports);
                }
                else
                {
                    foundAirports = new StatusCodeResult(204);
                }
            }
            else
            {
                foundAirports = new StatusCodeResult(500);
            }
            return foundAirports;
        }

    }
}
