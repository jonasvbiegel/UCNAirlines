using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirlineData.Model;
using AirlineData.DataAccessLayer;
using AirlineData.BusinessLayer;

namespace APIService.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SeatsController : ControllerBase
{
    TestData td = new();

    [HttpGet]
    public ActionResult<List<Seat>> GetSeats()
    {
        return Ok(td.Seats);
    }

    [HttpGet("{airplaneId}")]
    public ActionResult<List<Seat>> GetSeatsFromAirplane(string airplaneId, [FromHeader] DateTime depart)
    {
        List<Seat?> seats = new();

        foreach (Seat s in td.Seats)
        {
            if (s.Flight.Airplane.AirplaneId == airplaneId && s.Flight.Departure == depart) seats.Add(s);
        }

        if (seats == null) return NotFound();
        return Ok(seats);
    }

    [HttpPut("{airplaneId}")]
    public ActionResult<Seat> UpdateSeat(string airplaneId, [FromHeader] DateTime depart, [FromHeader] string seatName, [FromHeader] bool newBookedStatus)
    {
        Flight? flight = td.Flights.Find(f => f.Airplane.AirplaneId == airplaneId && f.Departure == depart);

        Seat? foundSeat = td.Seats.Find(s => s.SeatName == seatName && s.Flight == flight);

        if (foundSeat != null)
        {
            foundSeat.IsBooked = true;
            return Ok(foundSeat);
        }

        return NotFound();
    }

}


