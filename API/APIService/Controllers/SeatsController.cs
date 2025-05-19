using Microsoft.AspNetCore.Mvc;
using AirlineData.ModelLayer;
using APIService.BusinessLayer;
using Microsoft.IdentityModel.Tokens;
using APIService.DTOs;
using APIService.ModelConversion;


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
        
        return Ok(_seatLogic.GetSeats());
    }

    // Returns seats from a specific flight
    // GET /api/seats/flightId?flightId={id}
    [HttpGet("flightId")]
    public ActionResult<List<SeatDTO>> GetSeatsFromAirplane(int flightId)
    {
        List<SeatDTO?>? listOfSeats = _seatLogic.GetSeatsFromFlight(flightId);
        if (listOfSeats.IsNullOrEmpty()) return new StatusCodeResult(204);
        return Ok(listOfSeats);
    }

    // Gets a specific seat from id
    // GET /api/seats/{seatId}
    [HttpGet("{seatId}")]
    public ActionResult<SeatDTO> GetSeat(int seatId)
    {
        SeatDTO? seat = _seatLogic.GetSeat(seatId);
        if (seat == null) return new StatusCodeResult(204);
        return Ok(seat);
    }

    [HttpPost]
    public ActionResult<bool> TryBookSeats([FromBody] List<SeatDTO?>? seats)
    {
        bool updated = _seatLogic.TryBookSeats(seats);
        if (!updated) return new StatusCodeResult(500);

        return Ok(updated);
    }
}


