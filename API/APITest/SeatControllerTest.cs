using System.Text.Json;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text;

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
    public async void Test_GetSeatFromFlight()
    {
        //Arrange

        //This is what we are sending as the request
        string airplaneId = "CES123";
        string uri = baseUri + airplaneId;
        string date = "04/24/2025 20:00";

        // This is to test that it is the actual model we get back
        string airplaneModel = "Cessna";

        List<Seat>? seatsOfFlight = new();

        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Add("depart", "2025/04/25 20:00");

        //Act
        HttpResponseMessage response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            seatsOfFlight = await response.Content.ReadFromJsonAsync<List<Seat>>();
        }

        string foundAirplaneModel = seatsOfFlight.Find(s => s.SeatName == "1A").Flight.Airplane.Airline;

        //Assert
        Assert.NotEmpty(seatsOfFlight);
        Assert.Equal(airplaneModel, foundAirplaneModel);
    }

    [Fact]
    public async void Test_PutSeatStatus()
    {
        //Arrange
        Seat returnedSeat = new();

        SeatDatabaseAccess sdb = new();

        Flight? flightToUpdate = sdb.Flights.Find(f => f.Airplane.AirplaneId == "CES123");
        Seat? seatToPut = sdb.Seats.Find(s => s.SeatName == "1A" && s.Flight.Airplane.AirplaneId == flightToUpdate.Airplane.AirplaneId);
        seatToPut.IsBooked = true;

        string json = JsonSerializer.Serialize(seatToPut);
        //Act
        HttpResponseMessage response = await client.PutAsync(baseUri, new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

        if (response.IsSuccessStatusCode)
        {
            returnedSeat = await response.Content.ReadFromJsonAsync<Seat>();
        }

        //Assert
        Assert.Equal("CES123", returnedSeat.Flight.Airplane.AirplaneId);
        Assert.True(returnedSeat.IsBooked);
    }
}
