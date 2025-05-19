using UCNAirlinesWebpage.Controllers;
using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;
using Xunit;


namespace TestUCNAirlineWebpage
{
    public class TestFlightroute
    {

        [Fact]
        public void Test_StartAndEndCannotBeTheSame()
        {
            //    //Arrange
            //    string startDestination = "Aalborg";
            //    string endDestination = "Aalborg";

        }
        [Fact]
        public async void FlightgetTest()
        {
            FlightServiceAccess fsa = new FlightServiceAccess();
            Flight f=await fsa.GetFlight(3);
            string s=f.Airplane.Airline;
            Assert.NotNull(f);
            Assert.Equal("UCN", s);
        }
        
    }
}

