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

    private readonly string _connectionString = "Data Source = localhost; Initial Catalog = UCNAirlines; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

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
    public async void DBTest_Concurrency()
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

        // var task1 = TryBook(seats1);
        // var task2 = TryBook(seats2);

        bool update1 = false;
        bool update2 = false;
        // Thread t1 = new Thread(new ThreadStart(TryBook(seats1)));
        Thread t1 = new Thread(() => update1 = TryBook(seats1));
        t1.Start();
        // Thread t2 = new Thread(() => update2 = TryBook(seats2));
        // t2.Start();

        update2 = TryBook(seats2);

        // Thread.Sleep(100000000);
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


//     static private readonly IPassengerDB passengerDB = new PassengerDB();
// private readonly IPassengerLogic passengerLogic = new PassengerLogic(passengerDB);
//
// static private readonly ISeatDB seatDB = new SeatDB();
// private readonly ISeatLogic seatLogic = new SeatLogic(seatDB);

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


// [Fact]
//     public void DBTest_ConcurrencyTest()
//     {
//         // For this test we will be splitting the query up in 2 parts for one of the updates. The first part will get the row version and the second part will try to update the seat after the row version has been changed. This should output an error.
//
//         // This is the query that will be run against the database in full
//         // @"
//         // DECLARE @rv rowversion = (SELECT row_version FROM Seat WHERE seat_id = @SeatId);
//         // DECLARE @key TABLE (seat_id int);
//         // UPDATE Seat
//         // SET passport_no_FK = @PassportNo
//         //     OUTPUT inserted.seat_id INTO @key(seat_id)
//         // WHERE seat_id = @SeatId
//         //     AND row_version = @rv
//         // IF (SELECT COUNT(*) FROM @key) = 0
//         //     BEGIN
//         //         RAISERROR ('error changing row with seat_id = %d'
//         //                 , 16
//         //                 , 1
//         //                 , @SeatId)
//         //         END;
//         // ";
//
//
//         //Arrange
//         Byte[] rowVersion = null;
//         int seatIdToBeUpdated = 3;
//         Seat seatQuery = _seatDB.GetSeat(1);
//         seatQuery.SeatId = seatIdToBeUpdated;
//
//         string sqlSelectRowVersion = $"SELECT row_version FROM Seat WHERE seat_id = @SeatId";
//
//         string sqlUpdate = @"
//         DECLARE @key TABLE (seat_id int);
//         UPDATE Seat
//         SET passport_no_FK = @PassportNo
//             OUTPUT inserted.seat_id INTO @key(seat_id)
//         WHERE seat_id = @SeatId
//             AND row_version = @RV
//         IF (SELECT COUNT(*) FROM @key) = 0
//             BEGIN
//                 RAISERROR ('error changing row with seat_id = %d'
//                         , 16
//                         , 1
//                         , @SeatId)
//                 END;
//             ";
//
//         //Act
//
//         // Here we are getting the row version before executing an update
//         using SqlConnection con = new(_connectionString);
//         using (var reader = con.ExecuteReader(sqlSelectRowVersion, new { SeatId = seatIdToBeUpdated }))
//         {
//             while (reader.Read())
//             {
//                 rowVersion = (Byte[])reader["row_version"];
//             }
//         }
//
//         // Now we execute an update on the seat to update the rowversion
//         bool success = _seatDB.UpdateSeat(seatQuery);
//         Console.WriteLine(success);
//
//         //Assert
//         // Now we execute the second update, which is the last part of the split query
//         // This is done in assert because we are trying to see if the call throws an SqlException
//         SqlException exception = Assert.Throws<SqlException>(() =>
//                 con.Execute(sqlUpdate, new
//                 {
//                     SeatId = seatIdToBeUpdated,
//                     PassportNo = seatQuery.Passenger.PassportNo,
//                     RV = rowVersion
//                 })
//         );
//
//         Assert.True(success);
//         Assert.Equal($"error changing row with seat_id = {seatIdToBeUpdated}", exception.Message);
//     }
