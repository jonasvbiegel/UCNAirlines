using APIService.Controllers;
using Microsoft.AspNetCore.Mvc.Core;

namespace APITest;

public class SeatControllerTest
{
    SeatsController sc = new();

    [Fact]
    public void GetSeats()
    {
        var lol = sc.GetSeats();
        var a = lol.Result;
        var b = a.ExecuteResult(a);
    }
}
