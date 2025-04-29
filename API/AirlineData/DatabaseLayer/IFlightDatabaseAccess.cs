using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer
{
    public interface IFlightDatabaseAccess
    {
        Flight GetFlightById(int id);
        List<Flight> GetAllFlights();
        int CreateFlight(Flight flight);
        bool UpdateFlight(Flight flight);
        bool DeleteFlightById(int id);
        List<Flight> GetAllFlightsByDate(DateTime date);

    }
}
