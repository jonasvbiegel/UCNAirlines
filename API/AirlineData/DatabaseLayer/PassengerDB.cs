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

        var reader = con.ExecuteReader(sql, new { PassportNo = passportNo });

        Passenger? p = CreatePassengerFromReader(reader);

        return p;
    }

    public Passenger CreatePassenger(Passenger passenger)
    {
        string sql = "INSERT INTO Passenger VALUES (@PassportNo, @FirstName, @LastName, @BirthDate)";

        using SqlConnection con = new(_connectionString);

        int rows = con.Execute(sql, new
        {
            PassportNo = passenger.PassportNo,
            FirstName = passenger.FirstName,
            LastName = passenger.LastName,
            BirthDate = passenger.BirthDate.ToString("yyyy-MM-dd"),
        });

        if (rows != 1) return null;

        return passenger;
    }

    private Passenger CreatePassengerFromReader(IDataReader reader)
    {
        Passenger? p = new();

        while (reader.Read())
        {
            p.FirstName = (string)reader["first_name"];
            p.LastName = (string)reader["last_name"];
            p.BirthDate = DateOnly.FromDateTime((DateTime)reader["birth_date"]);
            p.PassportNo = (string)reader["passport_no"];
        }

        return p;
    }
}
