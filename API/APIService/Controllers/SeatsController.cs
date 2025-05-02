using Microsoft.AspNetCore.Mvc;
using AirlineData.ModelLayer;
using APIService.BusinessLayer;
// using AirlineData.DatabaseLayer;

using Microsoft.IdentityModel.Tokens;

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
    // GET /api/seats/UCN737? [departure from query]
    [HttpGet("flightId")]
    public ActionResult<List<Seat>> GetSeatsFromAirplane(int flightId)
    {
        List<Seat?>? listOfSeats = seatLogic.GetSeatsFromFlight(flightId);
        if (listOfSeats.IsNullOrEmpty()) return new StatusCodeResult(204);
        return Ok(listOfSeats);
    }

    [HttpGet("seatId")]
    public ActionResult<Seat> GetSeat(int seatId)
    {
        Seat? seat = seatLogic.GetSeat(seatId);
        if (seat == null) return new StatusCodeResult(204);
        return Ok(seat);
    }

    // Updates the IsBooked value of a specific seat
    // PUT /api/seats/UCN, Seat object in Body of request
    [HttpPut]
    public ActionResult<Seat> UpdateSeat(Seat seat)
    {
        // List<Flight>? flights = seatDatabaseAccess.Flights;
        // Flight? flight = flights.Find(f => f.Airplane.AirplaneId == seat.Flight.Airplane.AirplaneId && f.Departure == seat.Flight.Departure);
        //
        // Seat? foundSeat = seatDatabaseAccess.Seats.Find(s => s.SeatName == seat.SeatName && s.Flight == flight);
        //
        // if (foundSeat != null)
        // {
        //     foundSeat.IsBooked = seat.IsBooked;
        //     return Ok(foundSeat);
        // }
        //
        // return new StatusCodeResult(500);

        return NotFound();
    }

}


