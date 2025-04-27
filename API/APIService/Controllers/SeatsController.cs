using Microsoft.AspNetCore.Mvc;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;

namespace APIService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeatsController : ControllerBase
{
    private readonly SeatDatabaseAccess seatDatabaseAccess = new();

    // Returns all seats
    // GET /api/seats/
    [HttpGet]
    public ActionResult<List<Seat>> GetSeats()
    {
        return Ok(seatDatabaseAccess.Seats);
    }

    // Returns seats from a specific flight
    // GET /api/seats/UCN737 [departure from header]
    [HttpGet("{airplaneId}")]
    public ActionResult<List<Seat>> GetSeatsFromAirplane(string airplaneId, [FromHeader] DateTime depart)
    {
        List<Seat>? listOfSeats = seatDatabaseAccess.Seats;

        foreach (Seat s in listOfSeats)
        {
            if (s.Flight.Airplane.AirplaneId == airplaneId && s.Flight.Departure == depart) listOfSeats.Add(s);
        }


        if (listOfSeats == null) return NotFound();
        return Ok(listOfSeats);
    }

    // Updates the IsBooked value of a specific seat
    // PUT /api/seats/UCN 747 , takes a Seat object
    [HttpPut]
    public ActionResult<Seat> UpdateSeat(Seat seat)
    {

        List<Flight>? flights = seatDatabaseAccess.Flights;
        Flight? flight = flights.Find(f => f.Airplane.AirplaneId == seat.Flight.Airplane.AirplaneId && f.Departure == seat.Flight.Departure);

        Seat? foundSeat = seatDatabaseAccess.Seats.Find(s => s.SeatName == seat.SeatName && s.Flight == flight);

        if (foundSeat != null)
        {
            foundSeat.IsBooked = seat.IsBooked;
            return Ok(foundSeat);
        }

        return NotFound();
    }

}


