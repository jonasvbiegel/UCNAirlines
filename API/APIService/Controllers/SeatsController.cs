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
    private readonly SeatLogic seatLogic = new();

    // Returns all seats
    // GET /api/seats/
    [HttpGet]
    public ActionResult<List<Seat>> GetSeats()
    {
        return Ok(seatLogic.GetSeats());
    }

    // Returns seats from a specific flight
    // GET /api/seats/flightId?flightId={id}
    [HttpGet("flightId")]
    public ActionResult<List<Seat>> GetSeatsFromAirplane(int flightId)
    {
        List<Seat?>? listOfSeats = seatLogic.GetSeatsFromFlight(flightId);
        if (listOfSeats.IsNullOrEmpty()) return new StatusCodeResult(204);
        return Ok(listOfSeats);
    }

    // Gets a specific seat from id
    // GET /api/seats/{seatId}
    [HttpGet("{seatId}")]
    public ActionResult<Seat> GetSeat(int seatId)
    {
        Seat? seat = seatLogic.GetSeat(seatId);
        if (seat == null) return new StatusCodeResult(204);
        return Ok(seat);
    }

    // Updates the passport number of the given seat
    // PUT /api/seats/{seatId}, passport number in query
    [HttpPut("{seatId}")]
    public ActionResult<Seat> UpdateSeat(int seatId, [FromQuery] string passportNo)
    {
        bool updated = seatLogic.UpdateSeat(seatId, passportNo);

        if (!updated) return new StatusCodeResult(500);

        return Ok(updated);
    }
}


