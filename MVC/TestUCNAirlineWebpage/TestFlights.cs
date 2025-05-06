using UCNAirlinesWebpage.Controllers;
using UCNAirlinesWebpage.Models;
using Xunit;


namespace TestUCNAirlineWebpage
{
    public class TestFlights
    {
        public List<Flight> Flights { get; private set; }

        [Fact]
        public void Test_NoFlights()
        {
            //Arrange
            //Flights = new List<Flight>
            //      {
            //        new Flight(route1, null,departure1),
            //        new Flight(route2, null, departure2),
            //        new Flight(route3, null, departure1)
            //    };

            //Act

            /*var exception = Record.Exception(() => new Flightroute(startDestination, endDestination))*/
            ;

            //Assert
            //Assert.NotNull(exception);
            //Assert.IsType<ArgumentException>(exception);
            //Assert.Equal("StartDestination and EndDestination cannot be the same!", exception.Message);
        }
    }
}


