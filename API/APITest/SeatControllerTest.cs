//using System.Text.Json;
//using AirlineData.ModelLayer;
//using AirlineData.DatabaseLayer;
//using System.Net.Http.Json;
//using Microsoft.AspNetCore.Http;
//using System.Text;
//using Microsoft.AspNetCore.Mvc.Routing;

//namespace APITest;

//public class SeatControllerTest
//{
//    // I have chosen to integration test the controllers instead of unit testing them. Integration testing tests that the api actually works, and that is what is important for the controller.

//    static HttpClient client = new();
//    static string baseUri = "http://localhost:5243/api/seats/";

//    [Fact]
//    public async void Test_GetSeats()
//    {
//        //Arrange
//        List<Seat>? listOfSeats;

//        //Act
//        listOfSeats = await client.GetFromJsonAsync<List<Seat>>(baseUri);

//        //Assert
//        Assert.NotEmpty(listOfSeats);
//    }

//    [Fact]
//    public async void Test_GetSeatsFromFlight()
//    {
//        //Arrange
//        int expectedFlightId = 1;
//        List<Seat>? listOfSeats;
//        string url = $"{baseUri}flightId?flightId={expectedFlightId}";


//        //Act
//        listOfSeats = await client.GetFromJsonAsync<List<Seat>>(url);

//        //Assert
//        Assert.NotEmpty(listOfSeats);
//        Assert.True(listOfSeats.FindAll(s => s.Flight.FlightId == expectedFlightId).TrueForAll(s => s.Flight.FlightId == expectedFlightId));
//    }

//    [Fact]
//    public async void Test_PutSeatStatus()
//    {
//        //Arrange
//        Seat returnedSeat = new();

//        SeatDatabaseAccess sdb = new();

//        Flight? flightToUpdate = sdb.Flights.Find(f => f.Airplane.AirplaneId == "CES123");
//        Seat? seatToPut = sdb.Seats.Find(s => s.SeatName == "1A" && s.Flight.Airplane.AirplaneId == flightToUpdate.Airplane.AirplaneId);
//        seatToPut.IsBooked = true;

//        string json = JsonSerializer.Serialize(seatToPut);
//        //Act
//        HttpResponseMessage response = await client.PutAsync(baseUri, new StringContent(json, UnicodeEncoding.UTF8, "application/json"));

//        if (response.IsSuccessStatusCode)
//        {
//            returnedSeat = await response.Content.ReadFromJsonAsync<Seat>();
//        }

//        //Assert
//        Assert.Equal("CES123", returnedSeat.Flight.Airplane.AirplaneId);
//        Assert.True(returnedSeat.IsBooked);
//    }
//}
