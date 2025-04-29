using UCNAirlinesWebpage.Controllers;
using UCNAirlinesWebpage.Models;
using Xunit;


namespace TestUCNAirlineWebpage
{
    public class TestFlightroute
    {
        [Fact]
        public void Test_StartAndEndCannotBeTheSame()
        {
            //Arrange
            string startDestination = "Aalborg";
            string endDestination = "Aalborg";

            //Act
            
            var exception = Record.Exception(() => new Flightroute(startDestination, endDestination));

            //Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal("StartDestination and EndDestination cannot be the same!", exception.Message);
        }
    }
}

