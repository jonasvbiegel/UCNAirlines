using System.Text.Json;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace APITest;

// This is done to make sure the tests run in sequential order

[Collection("Sequential")]
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
        //Arrange
        Seat? seat = _seatDB.GetSeat(1);
        Passenger? passenger = seat.Passenger;

        Seat? seatToPut = _seatDB.GetSeat(3);
        seatToPut.Passenger = passenger;

        //Act
        bool success = _seatDB.UpdateSeat(seatToPut);
        Seat? updatedSeat = _seatDB.GetSeat(3);

        //Assert
        Assert.True(success);
        Assert.Equal(seatToPut.Passenger.PassportNo, updatedSeat.Passenger.PassportNo);
    }

    [Fact]
    public void DBTest_UpdateSeatToNull()
    {
        //Arrange
        Seat? seat = _seatDB.GetSeat(3);
        seat.Passenger = null;

        //Act
        bool success = _seatDB.UpdateSeat(seat);
        Seat? updatedSeat = _seatDB.GetSeat(3);

        //Assert
        Assert.True(success);
        Assert.Null(updatedSeat.Passenger);
    }
}
