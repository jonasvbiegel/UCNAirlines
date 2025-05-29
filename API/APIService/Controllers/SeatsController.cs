using Microsoft.AspNetCore.Mvc;
using AirlineData.ModelLayer;
using APIService.BusinessLayer;
using Microsoft.IdentityModel.Tokens;
using APIService.DTOs;
using APIService.ModelConversion;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;


namespace APIService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeatsController : ControllerBase
{
    // private readonly SeatLogic seatLogic = new();

    private readonly ISeatLogic _seatLogic;

    public SeatsController(ISeatLogic seatLogic)
    {
        _seatLogic = seatLogic;
    }

    // Returns all seats
    // GET /api/seats/
    [HttpGet]
    public ActionResult<List<SeatDTO>> GetSeats()
    {
        ActionResult result;
        try
        {
            List<SeatDTO> seats = _seatLogic.GetSeats();
            if (seats.Count > 0)
            {
                result = Ok(seats);
            }
            else
            {
                result = new StatusCodeResult(204);
            }
        }
        catch (SqlException)
        {
            result = StatusCode(500, "Something went wrong finding the seats.");
        }
        return result;
    }

    // Returns seats from a specific flight
    // GET /api/seats/flightId?flightId={id}
    [HttpGet("flightId")]
    public ActionResult<List<SeatDTO>> GetSeatsFromAirplane(int flightId)
    {
        ActionResult result;
        try
        {
            List<SeatDTO?>? listOfSeats = _seatLogic.GetSeatsFromFlight(flightId);
            if (listOfSeats.Count > 0)
            {
                result = Ok(listOfSeats);
            }
            else
            {
                result = new StatusCodeResult(204);
            }
        }
        catch (SqlException)
        {
            return StatusCode(500,"Something went wrong with retrieving seats on the specified flight.");
        }
        return result;  
    }

    // Gets a specific seat from id
    // GET /api/seats/{seatId}
    [HttpGet("{seatId}")]
    public ActionResult<SeatDTO> GetSeat(int seatId)
    {
        ActionResult result;
        try
        {
            SeatDTO? seat = _seatLogic.GetSeat(seatId);
            if (seat != null)
            {
                result= Ok(seat);
            }
            else
            {
                result = new StatusCodeResult(404);
            }
                
        }catch(SqlException){
            return StatusCode(500, "Something went wrong with finding the specified seat.");
        }
        return result;
    }

    [HttpPut]
    public ActionResult<bool> TryBookSeats([FromBody] List<SeatDTO?>? seats)
    {
        ActionResult result;
        try
        {
            bool updated = _seatLogic.TryBookSeats(seats);
            if (updated)
            {
                result= Ok(updated);
            }
            else
            {
                result = StatusCode(400);
            }
        }
        catch (SqlException)
        {
            return StatusCode(500, "Something went wrong with bookig choosing seats");
        }
        return result;
    }
}


