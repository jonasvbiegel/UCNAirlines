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

public class SeatBLTest
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

