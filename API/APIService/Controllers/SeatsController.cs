using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirlineData.Model;
using AirlineData.DataAccessLayer;

namespace APIService.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SeatsController : ControllerBase
{
    readonly static TestData testdata = new();
    readonly List<Seat> list = testdata.Seats;

    [HttpGet]
    public ActionResult<List<Seat>> GetSeats()
    {
        return Ok(list);
    }

    [HttpGet("{airplaneId}")]
    public ActionResult<List<Seat>> GetSeatsFromAirplane(string airplaneId, [FromHeader] DateTime depart)
    {
        List<Seat>? seats = testdata.FindSeatsByFlight(airplaneId, depart);

        if (seats == null) return NotFound();
        return Ok(seats);
    }

    [HttpPut("{airplaneId}")]
    public ActionResult<Seat>? UpdateSeat(string airplaneId, [FromHeader] DateTime depart, [FromHeader] string seatName, [FromHeader] bool newBookedStatus)
    {
        Flight? flight = testdata.Flights.Find(f => f.Airplane.AirplaneId == airplaneId && f.Departure == depart);

        if (flight != null)
        {
            Seat? updatedSeat = testdata.UpdateSeat(flight, seatName, newBookedStatus);
            return Ok(updatedSeat);
        }

        return NotFound();
    }

}


