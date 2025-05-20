using System.Text.Json;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace APITest;

// This is done to make sure the tests run in sequential order

[Collection("Sequential")]
public class PassengerDBTest
{
    // SeatDB sdb = new();

    // private readonly IPassengerDB _passengerDB = new PassengerDB();
    // private readonly string _connectionString = "Data Source = localhost; Initial Catalog = UCNAirlines; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";
    // [Fact]
    // public void DBTest_GetPassenger()
    // {
    //     //Arrange
    //     string passportNo = "12345678";
    //
    //     //Act
    //     Passenger? p = _passengerDB.GetPassenger(passportNo);
    //
    //     //Assert
    //     Assert.NotNull(p);
    //     Assert.Equal(passportNo, p.PassportNo);
    // }
    //
    // [Fact]
    // public void DBTest_CreatePassenger()
    // {
    //     //Arrange
    //     string passportNo = GenerateRandomPassportNo();
    //     Passenger p = new() { FirstName = "Test", LastName = "Testsen", PassportNo = passportNo, BirthDate = DateOnly.Parse("2000-01-01") };
    //
    //     //Act
    //     Passenger? pReturn = _passengerDB.CreatePassenger(p);
    //
    //     //Assert
    //     Assert.NotNull(pReturn);
    //     Assert.Equal(passportNo, pReturn.PassportNo);
    // }
    //
    // static private string GenerateRandomPassportNo()
    // {
    //     var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    //     var stringChars = new char[8];
    //     var random = new Random();
    //
    //     for (int i = 0; i < stringChars.Length; i++)
    //     {
    //         stringChars[i] = chars[random.Next(chars.Length)];
    //     }
    //
    //     var finalString = new String(stringChars);
    //
    //     return finalString;
    // }
    // [Fact]
    //
    // public void TestAirportDb()
    // {
    //
    //     AirportDatabaseAccess ada = new AirportDatabaseAccess(_connectionString);
    //     List<string> air = ada.GetAllAirports();
    //     Assert.Equal(5, air.Count);
    // }
}
