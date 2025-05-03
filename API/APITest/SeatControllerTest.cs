using System.Text.Json;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Routing;

namespace APITest;

public class SeatControllerTest
{
    // I have chosen to integration test the controllers instead of unit testing them. Integration testing tests that the api actually works, and that is what is important for the controller.

    static HttpClient client = new();
    static string baseUri = "http://localhost:5243/api/seats/";

    [Fact]
    public async void Test_GetSeats()
    {
        //Arrange
        List<Seat>? listOfSeats;

        //Act
        listOfSeats = await client.GetFromJsonAsync<List<Seat>>(baseUri);

        //Assert
        Assert.NotEmpty(listOfSeats);
    }

    [Fact]
    public async void Test_GetSeatsFromFlight()
    {
        //Arrange
        int flightId = 1;
        List<Seat>? listOfSeats;
        string expectedPassportNo = "12345678";
        string url = $"{baseUri}flightId?flightId={flightId}";


        //Act
        listOfSeats = await client.GetFromJsonAsync<List<Seat>>(url);

        //Assert
        Assert.NotEmpty(listOfSeats);
        Assert.Equal(expectedPassportNo, listOfSeats.First().Passenger.PassportNo);

    }

    // TODO: change PUT to take a Seat object :(

    // [Fact]
    // public async void Test_PutSeatStatus()
    // {
    //     //Arrange
    //     bool expectedValue = true;
    //     int flightId = 1;
    //     string expectedPassportNo = "12345678";
    //
    //     string url = $"{baseUri}{flightId}";
    //
    //     //Act
    //     var responseMessage = await client.PutAsync(url, new StringContent(expectedPassportNo));
    //     string actualValue = await responseMessage.Content.ReadAsStringAsync();
    //     //Assert
    //     Assert.Equal(expectedValue, Boolean.Parse(actualValue));
    // }
}
