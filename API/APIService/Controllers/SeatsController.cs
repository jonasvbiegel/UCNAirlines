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
    // PUT /api/seats/UCN 747 [departure, SeatName and NewBookedStatus from header]
    [HttpPut("{airplaneId}")]
    public ActionResult<Seat> UpdateSeat(string airplaneId, [FromHeader] DateTime depart, [FromHeader] string seatName, [FromHeader] bool newBookedStatus)
    {

        List<Flight>? flights = seatDatabaseAccess.Flights;
        Flight? flight = flights.Find(f => f.Airplane.AirplaneId == airplaneId && f.Departure == depart);

        Seat? foundSeat = seatDatabaseAccess.Seats.Find(s => s.SeatName == seatName && s.Flight == flight);

        if (foundSeat != null)
        {
            foundSeat.IsBooked = true;
            return Ok(foundSeat);
        }

        return NotFound();
    }

}


