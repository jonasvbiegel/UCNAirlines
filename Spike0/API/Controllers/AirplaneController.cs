using API.DataAccess;
// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using API.Model;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors(origins: "*", headers: "*", methods: "*")]
public class AirplaneController : ControllerBase
{

    private readonly AirplaneDB adb = AirplaneDB.Instance;

    private readonly ILogger<AirplaneController> _logger;

    public AirplaneController(ILogger<AirplaneController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAirplanes")]
    public IEnumerable<Airplane> GetAirplanes()
    {
        return adb.GetAirplanes();
    }

    [HttpPost(Name = "CreateAirplane")]
    public ActionResult<Airplane?> PostAirplane(Airplane airplane)
    {
        return adb.CreateAirplane(airplane);
    }
}

