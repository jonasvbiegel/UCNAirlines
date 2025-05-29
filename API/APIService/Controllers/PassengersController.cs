using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirlineData.ModelLayer;
using APIService.BusinessLayer;
using APIService.DTOs;
using Microsoft.Data.SqlClient;

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
        ActionResult result ;
        try
        {
            PassengerDTO? p = _passengerLogic.GetPassenger(passportNo);

            if (p != null)
            {
                result = Ok(p);
            }
            else
            {
                result = NotFound();
            }
        }catch(SqlException)
        {
            result = StatusCode(500,"Something went wrong with finding the passenger with specified passport number.");
        }
                return result;
    }

    [HttpPost]
    public ActionResult<Passenger> PostPassenger(PassengerDTO passenger)
    {
        ActionResult result;
        Passenger? p;

        try
        {
            p = _passengerLogic.CreatePassenger(passenger);
            
        }
        catch(SqlException)
        {
            return StatusCode(500,"Something went wrong with saving the passenger/s.");
        }

        return Ok(p);
    }
}

