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

        //Act
        listOfSeats = sdb.GetAllSeats();

        // listOfSeats = await client.GetFromJsonAsync<List<Seat>>(baseUri);

        //Assert
        Assert.NotEmpty(listOfSeats);
    }
}
