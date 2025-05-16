using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineData.ModelLayer;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AirlineData.DatabaseLayer
{
    public class AirportDatabaseAccess:IAirport
    {
        private readonly string? _connectionString;

        public AirportDatabaseAccess(IConfiguration inConfig)
        {

            _connectionString = inConfig.GetConnectionString("CompanyConnection");
        }

        // For test (convenience)
        public AirportDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }
        public List<string> GetAllAirports()
        {
            string sql = "SELECT airport_name FROM Airport";

            using SqlConnection con = new SqlConnection(_connectionString);
            con.Open();

            using SqlCommand cmd = new SqlCommand(sql, con);
            using SqlDataReader reader = cmd.ExecuteReader();

            List<string> airports = new();

            while (reader.Read())
            {
                // Use column name to get the value
                string airportName = (string)reader["airport_name"];
                if (airportName != null) // Ensure it's not null before adding
                {
                    airports.Add(airportName);
                }
            }

            return airports;
        }


    }
}
