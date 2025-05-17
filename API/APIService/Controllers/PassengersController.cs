using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirlineData.ModelLayer;
using APIService.BusinessLayer;
using APIService.DTOs;

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
    public ActionResult<PassengerDTO> GetPassenger(string passportNo)
    {
        PassengerDTO? p = _passengerLogic.GetPassenger(passportNo);

        if (p == null) return new StatusCodeResult(204);
        return Ok(p);
    }

    [HttpPost]
    public ActionResult<Passenger> PostPassenger(PassengerDTO passenger)
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

