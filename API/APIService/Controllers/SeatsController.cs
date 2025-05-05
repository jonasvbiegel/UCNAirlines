using Microsoft.AspNetCore.Mvc;
using AirlineData.ModelLayer;
using APIService.BusinessLayer;
using Microsoft.IdentityModel.Tokens;
// using AirlineData.DatabaseLayer;

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
    public ActionResult<List<Seat>> GetSeats()
    {
        return Ok(_seatLogic.GetSeats());
    }

    // Returns seats from a specific flight
    // GET /api/seats/flightId?flightId={id}
    [HttpGet("flightId")]
    public ActionResult<List<Seat>> GetSeatsFromAirplane(int flightId)
    {
        List<Seat?>? listOfSeats = _seatLogic.GetSeatsFromFlight(flightId);
        if (listOfSeats.IsNullOrEmpty()) return new StatusCodeResult(204);
        return Ok(listOfSeats);
    }

    // Gets a specific seat from id
    // GET /api/seats/{seatId}
    [HttpGet("{seatId}")]
    public ActionResult<Seat> GetSeat(int seatId)
    {
        Seat? seat = _seatLogic.GetSeat(seatId);
        if (seat == null) return new StatusCodeResult(204);
        return Ok(seat);
    }

    // Updates the passport number of the given seat
    // PUT /api/seats/, Seat object in body of request
    // if passportNo is "null", sets the passportNo to null in database
    [HttpPut]
    public ActionResult<Seat> UpdateSeat([FromBody] Seat seat)
    {
        bool updated = _seatLogic.UpdateSeat(seat);

        if (!updated) return new StatusCodeResult(500);

        return Ok(updated);
    }
}


