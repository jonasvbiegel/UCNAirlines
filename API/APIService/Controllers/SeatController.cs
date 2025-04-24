using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirlineData.Model;
using AirlineData.DataAccessLayer;

namespace APIService.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SeatController : ControllerBase
{
    readonly static TestData testdata = new();
    readonly List<Seat> list = testdata.Seats;

    [HttpGet]
    public ActionResult<List<Seat>> GetSeats()
    {
        return Ok(list);
    }

    [HttpGet("{seatName}")]
    public ActionResult<Seat> GetSeat(string seatName)
    {
        Seat? foundSeat = testdata.FindSeat(seatName);

        if (foundSeat != null) return Ok(foundSeat);
        return NotFound();
    }


}


