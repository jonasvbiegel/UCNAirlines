using System.Text.Json;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace APITest;

public class DatabaseTest
{

    [Fact]
    public void Test_GetSeatsFromDB()
    {
        //Arrange
        List<Seat>? listOfSeats;
        SeatDB sdb = new();

        string expectedIcaoCode = "AALB";
        string expectedSeatName = "1A";

        //Act
        listOfSeats = sdb.GetAllSeats();

        // listOfSeats = await client.GetFromJsonAsync<List<Seat>>(baseUri);

        //Assert

        // string actualIcaoCode = listOfSeats[0].Flight.Route.StartDestination.IcaoCode;
        // Assert.Equal(expectedIcaoCode, actualIcaoCode);

        // string actualSeatName = listOfSeats[0].SeatName;
        // string actualSeatName = listOfSeats.First().SeatName;
        // Assert.Equal(expectedSeatName, actualSeatName);

        foreach (Seat s in listOfSeats)
        {
            Console.WriteLine(s);
        }
        Assert.NotEmpty(listOfSeats);
    }
}
