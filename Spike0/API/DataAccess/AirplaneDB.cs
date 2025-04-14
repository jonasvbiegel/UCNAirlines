namespace API.DataAccess;

using API.Model;
using Microsoft.Data.SqlClient;
using Dapper;

public class AirplaneDB : IAirplaneDB
{
    private readonly string _connectionString = "Data Source = 79.171.148.149; Initial Catalog = Sprint0Spike; Persist Security Info=True; User ID = sa; Password=KhanhErSej123; Encrypt=False";

    private static AirplaneDB? _instance;

    public static AirplaneDB Instance
    {
        get
        {
            return _instance ?? new AirplaneDB();
        }
    }

    private AirplaneDB()
    {

    }

    public List<Airplane> GetAirplanes()
    {
        string sql = "SELECT * FROM Airplane";

        using SqlConnection con = new(_connectionString);

        con.Open();
        return con.Query<Airplane>(sql).ToList();
    }

    public Airplane? GetAirplane(string airplaneId)
    {
        string sql = "SELECT * FROM Airplane WHERE airplane_id = @Airplane_id";

        using SqlConnection con = new(_connectionString);

        con.Open();
        return con.QueryFirstOrDefault<Airplane>(sql, new { @Airplane_id = airplaneId });
    }
}
