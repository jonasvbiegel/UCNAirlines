using System.Text.Json;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Routing;

namespace APITest;

[Collection("Sequential")]
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
    public async void Test_GetSeat()
    {
        //Arrange
        Seat seat;
        int seatId = 1;
        string url = $"{baseUri}{seatId}";

        //Act
        seat = await client.GetFromJsonAsync<Seat>(url);

        //Assert
        Assert.NotNull(seat);
        Assert.Equal(seatId, seat.SeatId);
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

    [Fact]
    public async void Test_PutSeat()
    {
        //Arrange
        Seat? seatToUpdate;
        Seat? updatedSeat;
        int seatToUpdateId = 1;
        int updatedSeatId = 3;

        string urlPut = $"{baseUri}{seatToUpdateId}";
        string urlUpdated = $"{baseUri}{updatedSeatId}";

        //Act
        seatToUpdate = await client.GetFromJsonAsync<Seat>(urlPut);

        seatToUpdate.SeatId = updatedSeatId;

        string jsonObject = JsonSerializer.Serialize(seatToUpdate);

        var httpContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PutAsync(baseUri, httpContent);

        var responseBody = await response.Content.ReadAsStringAsync();

        updatedSeat = await client.GetFromJsonAsync<Seat>(urlUpdated);

        //Assert
        Assert.Equal("true", responseBody);
        Assert.Equal(seatToUpdate.Passenger.PassportNo, updatedSeat.Passenger.PassportNo);
    }

    [Fact]
    public async void Test_PutSeatNull()
    {
        //Arrange
        Seat? seatToUpdate;
        Seat? updatedSeat;
        int seatToUpdateId = 1;
        int updatedSeatId = 3;

        string urlPut = $"{baseUri}{seatToUpdateId}";
        string urlUpdated = $"{baseUri}{updatedSeatId}";

        //Act
        seatToUpdate = await client.GetFromJsonAsync<Seat>(urlPut);

        seatToUpdate.SeatId = updatedSeatId;
        seatToUpdate.Passenger = null;

        string jsonObject = JsonSerializer.Serialize(seatToUpdate);

        var httpContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
        var response = await client.PutAsync(baseUri, httpContent);

        var responseBody = await response.Content.ReadAsStringAsync();

        updatedSeat = await client.GetFromJsonAsync<Seat>(urlUpdated);

        //Assert
        Assert.Equal("true", responseBody);
        Assert.Null(updatedSeat.Passenger);
    }
}
