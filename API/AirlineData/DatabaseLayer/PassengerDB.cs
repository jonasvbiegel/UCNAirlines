using AirlineData.ModelLayer;
using System.Data;
using System.Runtime.CompilerServices;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AirlineData.DatabaseLayer;

public class PassengerDB : IPassengerDB
{
    private readonly string _connectionString = "Data Source = localhost; Initial Catalog = UCNAirlines; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

    public Passenger? GetPassenger(string passportNo)
    {
        string sql = "SELECT * FROM Passenger WHERE passport_no = @PassportNo";

        using SqlConnection con = new(_connectionString);

        Passenger? p = con.Query<Passenger>(sql).FirstOrDefault();

        return p;
    }

    public Passenger CreatePassenger(Passenger passenger)
    {
        string sql = "INSERT INTO Passenger VALUES (@PassportNo, @FirstName, @LastName, @DateOfBirth)";

        using SqlConnection con = new(_connectionString);

        int rows = con.Execute(sql, new
        {
            PassportNo = passenger.PassportNo,
            FirstName = passenger.FirstName,
            LastName = passenger.LastName,
            DateOfBirth = passenger.BirthDate
        });

        if (rows != 1) return null;

        return passenger;
    }
}
