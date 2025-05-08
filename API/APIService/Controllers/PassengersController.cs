using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirlineData.ModelLayer;
using APIService.BusinessLayer;

namespace APIService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PassengersController : ControllerBase
{
    private readonly IPassengerLogic _passengerLogic;

    public PassengersController(IPassengerLogic passengerLogic)
    {
        _passengerLogic = passengerLogic;
    }

    [HttpGet("{passportNo}")]
    public ActionResult<Passenger> GetPassenger(string passportNo)
    {
        Passenger? p = _passengerLogic.GetPassenger(passportNo);

        if (p == null) return new StatusCodeResult(204);
        return Ok(p);
    }

    [HttpPost]
    public ActionResult<Passenger> PostPassenger(Passenger passenger)
    {
        Passenger? p;

        try
        {
            p = _passengerLogic.CreatePassenger(passenger);
        }
        catch
        {
            return new StatusCodeResult(500);
        }

        return Ok(p);
    }
}

