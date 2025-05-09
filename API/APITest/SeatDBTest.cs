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

        // //Assert
        Assert.NotNull(seat);
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
    public void DBTest_ConcurrencyTest()
    {
        // For this test we will be splitting the query up in 2 parts for one of the updates. The first part will get the row version and the second part will try to update the seat after the row version has been changed. This should output an error.

        // This is the query that will be run against the database in full
        // @"
        // DECLARE @rv rowversion = (SELECT row_version FROM Seat WHERE seat_id = @SeatId);
        // DECLARE @key TABLE (seat_id int);
        // UPDATE Seat
        // SET passport_no_FK = @PassportNo
        //     OUTPUT inserted.seat_id INTO @key(seat_id)
        // WHERE seat_id = @SeatId
        //     AND row_version = @rv
        // IF (SELECT COUNT(*) FROM @key) = 0
        //     BEGIN
        //         RAISERROR ('error changing row with seat_id = %d'
        //                 , 16
        //                 , 1
        //                 , @SeatId)
        //         END;
        // ";


        //Arrange
        Byte[] rowVersion = null;
        int seatIdToBeUpdated = 3;
        Seat seatQuery = _seatDB.GetSeat(1);
        seatQuery.SeatId = seatIdToBeUpdated;

        string sqlSelectRowVersion = $"SELECT row_version FROM Seat WHERE seat_id = @SeatId";

        string sqlUpdate = @"
        DECLARE @key TABLE (seat_id int);
        UPDATE Seat
        SET passport_no_FK = @PassportNo
            OUTPUT inserted.seat_id INTO @key(seat_id)
        WHERE seat_id = @SeatId
            AND row_version = @RV
        IF (SELECT COUNT(*) FROM @key) = 0
            BEGIN
                RAISERROR ('error changing row with seat_id = %d'
                        , 16
                        , 1
                        , @SeatId)
                END;
            ";

        //Act

        // Here we are getting the row version before executing an update
        using SqlConnection con = new(_connectionString);
        using (var reader = con.ExecuteReader(sqlSelectRowVersion, new { SeatId = seatIdToBeUpdated }))
        {
            while (reader.Read())
            {
                rowVersion = (Byte[])reader["row_version"];
            }
        }

        // Now we execute an update on the seat to update the rowversion
        bool success = _seatDB.UpdateSeat(seatQuery);
        Console.WriteLine(success);

        //Assert
        // Now we execute the second update, which is the last part of the split query
        // This is done in assert because we are trying to see if the call throws an SqlException
        SqlException exception = Assert.Throws<SqlException>(() =>
                con.Execute(sqlUpdate, new
                {
                    SeatId = seatIdToBeUpdated,
                    PassportNo = seatQuery.Passenger.PassportNo,
                    RV = rowVersion
                })
        );

        Assert.Equal($"error changing row with seat_id = {seatIdToBeUpdated}", exception.Message);
    }
}
