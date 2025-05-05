using System.Text.Json;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Routing;

namespace APITest;

[Collection("Sequential")]
public class PassengerControllerTest
{
    // I have chosen to integration test the controllers instead of unit testing them. Integration testing tests that the api actually works, and that is what is important for the controller.

    static HttpClient client = new();
    static string baseUri = "http://localhost:5243/api/passengers/";

    [Fact]
    public async void Test_GetPassenger()
    {
        //Arrange
        Passenger? p;
        string passportNo = "12345678";
        string url = $"{baseUri}{passportNo}";

        //Act
        p = await client.GetFromJsonAsync<Passenger>(url);

        //Assert
        Assert.NotNull(p);
        Assert.Equal(passportNo, p.PassportNo);
    }

    [Fact]
    public async void Test_PostPassenger()
    {
        //Arrange
        Passenger pPost = new() { FirstName = "Hans", LastName = "Thomsen", PassportNo = GenerateRandomPassportNo(), BirthDate = DateOnly.Parse("1500-10-10") };
        Passenger? pReturn;

        //Act
        var response = await client.PostAsJsonAsync<Passenger>(baseUri, pPost);
        pReturn = await response.Content.ReadFromJsonAsync<Passenger>();

        //Assert
        Assert.NotNull(pReturn);
        Assert.Equal(pPost.PassportNo, pReturn.PassportNo);
    }

    static private string GenerateRandomPassportNo()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[8];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);

        return finalString;
    }
}
