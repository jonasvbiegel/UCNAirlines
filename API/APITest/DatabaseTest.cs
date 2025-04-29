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
    public void DBTest_GetSeats()
    {
        //Arrange
        List<Seat>? listOfSeats;
        SeatDB sdb = new();

        string expectedIcaoCode = "AALB";
        string expectedSeatName = "1A";

        //Act
        listOfSeats = sdb.GetAllSeats();

        //Assert
        Assert.Equal(expectedIcaoCode, listOfSeats.First().Flight.Route.StartDestination.IcaoCode);
        Assert.True(listOfSeats.FindAll(s => s.Flight.FlightId == 1).TrueForAll(s => s.Flight.Route.StartDestination.IcaoCode == expectedIcaoCode));
        Assert.NotEmpty(listOfSeats);
    }

    [Fact]
    public void DBTest_GetSeatsFromFlight()
    {
        //Arrange
        SeatDB sdb = new();

        List<Seat>? listOfSeats;
        int expectedFlightRouteId = 1;

        //Act
        listOfSeats = sdb.GetSeatsFromFlight(expectedFlightRouteId);

        //Assert

        Assert.NotEmpty(listOfSeats);
        Assert.True(listOfSeats.TrueForAll(s => s.Flight.FlightId == expectedFlightRouteId));
    }

}
