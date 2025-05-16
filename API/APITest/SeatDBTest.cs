using System.Text.Json;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;

namespace APITest;

// This is done to make sure the tests run in sequential order
[Collection("Sequential")]

public class SeatDBTest
{
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
        Console.WriteLine(seat.SeatId);

        // //Assert
        Assert.NotNull(seat);
        Assert.Equal(1, seat.SeatId);
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

    [Fact]
    public void DBTest_Concurrency()
    {
        IPassengerDB passengerDB = new PassengerDB();

        List<Seat?>? seats1 = new();
        List<Seat?>? seats2 = new();

        for (int i = 5; i <= 15; i++)
        {
            seats1.Add(_seatDB.GetSeat(i));
            seats2.Add(_seatDB.GetSeat(i));
        }

        Passenger p1 = passengerDB.GetPassenger("12345678");
        Passenger p2 = passengerDB.GetPassenger("87654321");

        seats1.ForEach(s => s.Passenger = p1);
        seats2.ForEach(s => s.Passenger = p2);

        bool update1 = _seatDB.TryUpdateSeats(seats1);

        Assert.True(update1);

    }

    public bool TryBook(List<Seat?>? seats)
    {
        bool success = _seatDB.TryUpdateSeats(seats);
        if (success)
        {
            Console.WriteLine($"{seats[0].Passenger.PassportNo} I wrote!!");
            return true;
        }
        else
        {
            Console.WriteLine($"{seats[0].Passenger.PassportNo} I failed :(");
            return false;
        }
    }

}
