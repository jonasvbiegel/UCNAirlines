using AirlineData.DatabaseLayer;
using Xunit.Abstractions;

namespace DataAccessTest
{
    public class DatabaseAccessTest
    {
        private readonly string _connectionString = "Data Source=localhost; Database=UCNAirlines; User ID=sa; Password=@12tf56so; Encrypt=false; trustServerCertificate=true";  // Replace with your actual connection string
        private readonly FlightDatabaseAccess _dbAccess;
        private readonly ITestOutputHelper _extraOutput;

        public DatabaseAccessTest(ITestOutputHelper tOutput)
        {
            // Initialize the FlightDatabaseAccess instance with the connection string
            _dbAccess = new FlightDatabaseAccess(_connectionString);
            _extraOutput = tOutput;
        }

        [Fact]
        public void Get_Flights()
        {
            var flights = _dbAccess.GetFlight_s();
            foreach (var flight in flights)
            {
                _extraOutput.WriteLine(flight.ToString());
            }
            Assert.NotNull(flights);
        }

    }
}