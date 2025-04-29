using UCNAirlinesWebpage.Controllers;
using UCNAirlinesWebpage.Models;


namespace TestUCNAirlineWebpage
{
    public class TestSelectFlight
    {

        public List<Flight> Flights { get; private set; }

        [Fact]  
        public void Test_FlightroutecannotBeNull()
        {
            //Arrange
        
            DateTime departure1 = DateTime.Today.AddHours(10);
            DateTime departure2 = DateTime.Today.AddHours(22);
            var airplane1 = new Airplane("NotBoeingA");
            var airplane2 = new Airplane("NotBoeingB");

            var route1 = new Flightroute("Aalborg", "Nuuk");
            var route2 = new Flightroute("Aalborg", "Nuuk");
            var route3 = new Flightroute(null, null);

            Flights = new List<Flight>
                  {
                    new Flight(route1, airplane1,departure1),
                    new Flight(route2, airplane2, departure2),
                    new Flight(route3, airplane2, departure1)
                };

            //Act
            FlightController fc = new FlightController(); 

            //Assert
            Assert.Throws<NullRouteException>(() => fc.VerifyFlight(Flights));
        }
    }
}