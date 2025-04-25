using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirlineData.Model;
// using AirlineData.DataAccessLayer;
using AirlineData.BusinessLayer;

namespace APIService.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SeatsController : ControllerBase
{
    readonly static SeatLogic seatLogic = new();
    // readonly List<Seat> list = testdata.Seats;

    [HttpGet]
    public ActionResult<List<Seat>> GetSeats()
    {
        return Ok(seatLogic.Seats);
    }

    [HttpGet("{airplaneId}")]
    public ActionResult<List<Seat>> GetSeatsFromAirplane(string airplaneId, [FromHeader] DateTime depart)
    {
        List<Seat>? seats = seatLogic.FindSeatsByFlight(airplaneId, depart);

        if (seats == null) return NotFound();
        return Ok(seats);
    }

    [HttpPut("{airplaneId}")]
    public ActionResult<Seat> UpdateSeat(string airplaneId, [FromHeader] DateTime depart, [FromHeader] string seatName, [FromHeader] bool newBookedStatus)
    {
        // Flight? flight = seatLogic.Flights.Find(f => f.Airplane.AirplaneId == airplaneId && f.Departure == depart);

        List<Seat>? seats = seatLogic.FindSeatsByFlight(airplaneId, depart);

        Seat? foundSeat = seats.Find(s => s.SeatName == seatName);



        if (foundSeat != null)
        {
            // Seat? updatedSeat = seatLogic.UpdateSeat(flight, seatName, newBookedStatus);
            foundSeat.IsBooked = true;
            return Ok(foundSeat);
        }

        return NotFound();
    }

}


