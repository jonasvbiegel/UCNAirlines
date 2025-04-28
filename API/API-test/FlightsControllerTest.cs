using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using FlightRestService.BusinessLogicLayer;
using FlightRestService.Controllers;
using FlightRestService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace API_test
{
    public class FlightsControllerTest
    {
        private readonly FlightsController _controller;

        public FlightsControllerTest()
        {
            //Opretter BusinessLogic og giver den flightDatabaseAccess
            IFlightData hardcodedFlightDataLogic = new FlightDataLogic(new FlightDatabaseAccess());
            _controller = new FlightsController(hardcodedFlightDataLogic);
        }
        [Fact]
        public void GetAllFlights_ShouldReturnAListOfFlights()
        {
            // Arrange
            DateTime testDate = new DateTime(2025, 10, 5, 16, 30, 0);

            //Act 
            ActionResult<List<FlightDTO>> result = _controller.GetAllFlights(testDate);

            // Assert: Tjekker at det er et 200 OK-resultat - så API'en svarer med den forventede HTTP-statuskode
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);

            // Tjekker at værdien er en liste af FlightDTO
            List<FlightDTO> flights = Assert.IsType<List<FlightDTO>>(okResult.Value);

            // Tjekker at listen ikke er tom
            Assert.NotEmpty(flights);
        }
        [Fact]
        public void GetAllNonExistingFlights_ShouldReturn204NoContent()
        {
            // Arrange
            DateTime testNoExistingDate = new DateTime(2025, 5, 3, 14, 30, 0);

            //Act 
            ActionResult<List<FlightDTO>> result = _controller.GetAllFlights(testNoExistingDate);

            // Assert: Tjekker at det er et 204 No Content-resultat
            StatusCodeResult statusCodeResult = Assert.IsType<StatusCodeResult>(result.Result);

            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public void GetFlightById_ShouldReturnChosenFlight()
        {
            // Arrange
            int testId = 1;

            //Act 
            ActionResult<FlightDTO> result = _controller.Get(testId);

            // Assert:
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);

            FlightDTO flightDTO = Assert.IsType<FlightDTO>(okResult.Value);

            //Da ID ikke findes i FlightDTO, tester jeg to andre attributter
            //Sammenligner Departure og Arrival airport med det i databasen
            Assert.Equal("Copenhagen", flightDTO.Route.DepartureAirport);
            Assert.Equal("Nuuk", flightDTO.Route.ArrivalAirport);

        }

        [Fact]
        public void getFlightById_NotFound_ShouldReturn404()
        {
            // Arrange
            int nonExistingFlight = 99;
            //Act 
            ActionResult<FlightDTO> result = _controller.Get(nonExistingFlight);
            
            //Tjekker at statuskoden er 500 som i Controlleren
            StatusCodeResult statusCodeResult = Assert.IsType<StatusCodeResult>(result.Result);
            Assert.Equal(404, statusCodeResult.StatusCode);
        }   


    }
}