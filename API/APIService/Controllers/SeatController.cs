using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirlineData.Model;
using AirlineData.DataAccessLayer;

namespace APIService.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SeatController : ControllerBase
{
    static TestData testdata = new();
    List<Seat> list = testdata.Seats;

    [HttpGet]
    public ActionResult<List<Seat>> GetSeats()
    {
        return Ok(list);
    }
}


