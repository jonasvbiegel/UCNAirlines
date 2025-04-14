using API.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Model;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
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
}

