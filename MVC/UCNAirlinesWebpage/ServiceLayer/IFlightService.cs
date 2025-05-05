using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.ServiceLayer
{
    public interface IFlightService
    {
        List<Flight> GetAllFlights();
        Flight GetFlightById(int id);

        void createFlight(Flight flight);
        void updateFlight(Flight flight);
        void deleteFlight(int id);  
    }
}
