using System.Text.Json;
using AirlineData.ModelLayer;
using AirlineData.DatabaseLayer;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;
using APIService.BusinessLayer;

namespace APITest;

// This is done to make sure the tests run in sequential order

public class SeatBLTest
{

    // private readonly IPassengerLogic _passengerLogic;
    // private readonly ISeatLogic _seatLogic;
    //
    // public SeatBLTest(ISeatLogic seatLogic, IPassengerLogic passengerLogic)
    // {
    //     _seatLogic = seatLogic;
    //     _passengerLogic = passengerLogic;
    // }

    // static private readonly IPassengerDB passengerDB = new PassengerDB();
    // private readonly IPassengerLogic passengerLogic = new PassengerLogic(passengerDB);
    //
    // static private readonly ISeatDB seatDB = new SeatDB();
    // private readonly ISeatLogic seatLogic = new SeatLogic(seatDB);
    //
    // [Fact]
    // public async void Concurrency()
    // {
    //     List<Seat> seats1 = new();
    //     List<Seat> seats2 = new();
    //
    //     for (int i = 5; i <= 105; i++)
    //     {
    //         seats1.Add(seatLogic.GetSeat(i));
    //         seats2.Add(seatLogic.GetSeat(i));
    //     }
    //
    //     Passenger p1 = passengerLogic.GetPassenger("12345678");
    //     Passenger p2 = passengerLogic.GetPassenger("87654321");
    //
    //     seats1.ForEach(s => s.Passenger = p1);
    //     seats2.ForEach(s => s.Passenger = p2);
    //
    //
    //     bool booking1 = await TryBook(seats1);
    //     bool booking2 = await TryBook(seats2);
    //
    //     Assert.NotEqual(booking1, booking2);
    // }
    //
    // public async Task<bool> TryBook(List<Seat> seats)
    // {
    //     return await Task.Run(() => seatLogic.TryBookSeats(seats));
    // }
}
