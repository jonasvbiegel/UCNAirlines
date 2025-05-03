using System.Text.Json;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace APITest;

public class DatabaseTest
{
    // SeatDB sdb = new();

    private readonly ISeatDB _seatDB = new SeatDB();

    [Fact]
    public void DBTest_GetSeats()
    {
        //Arrange
        List<Seat?>? listOfSeats;

        string expectedSeatName = "1A";
        string expectedPassportNo = "12345678";

        //Act
        listOfSeats = _seatDB.GetAllSeats();

        //Assert
        // Assert.NotEmpty(listOfSeats);
        // Assert.Equal(expectedIcaoCode, listOfSeats.First().Flight.Route.StartDestination.IcaoCode);
        // Assert.True(listOfSeats.FindAll(s => s.Flight.FlightId == 1).TrueForAll(s => s.Flight.Route.StartDestination.IcaoCode == expectedIcaoCode));

        Assert.NotEmpty(listOfSeats);
        Assert.Equal(expectedPassportNo, listOfSeats.First().Passenger.PassportNo);
        Assert.Equal(expectedSeatName, listOfSeats.First().SeatName);
    }

    [Fact]
    public void DBTest_GetSeatsFromFlight()
    {
        // Arrange
        List<Seat?>? seats;

        string expectedPassportNo = "12345678";

        //Act
        seats = _seatDB.GetSeatsFromFlight(1);

        //Assert
        Assert.Equal(expectedPassportNo, seats.First().Passenger.PassportNo);
    }

    [Fact]
    public void DBTest_GetSeat()
    {
        // //Arrange
        Seat? seat;

        string expectedPassportNo = "12345678";

        //Act
        seat = _seatDB.GetSeat(1);

        // //Assert
        Assert.NotNull(seat);
        Assert.Equal(expectedPassportNo, seat.Passenger.PassportNo);
    }

    [Fact]
    public void DBTest_UpdateSeatPassenger()
    {
        // Arrange
        bool expectedValue = true;
        string passportNo = "12345678";
        int flightId = 1;

        // Act 
        bool actualValue = _seatDB.UpdateSeat(flightId, passportNo);
        string actualPassportNo = _seatDB.GetSeat(flightId).Passenger.PassportNo;

        // Assert
        Assert.Equal(expectedValue, actualValue);
        Assert.Equal(passportNo, actualPassportNo);
    }

    [Fact]
    public void DBTest_UpdateSeatToNull()
    {
        //Arrange
        bool expectedValue = true;
        string passportNo = "null";
        int flightId = 1;

        //Act
        bool actualValue = _seatDB.UpdateSeat(flightId, passportNo);
        Passenger passenger = _seatDB.GetSeat(flightId).Passenger;

        //Assert
        Assert.Equal(expectedValue, actualValue);
        Assert.Null(passenger);
    }
}
