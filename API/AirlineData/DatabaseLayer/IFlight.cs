using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer
{
    public interface IFlight
    {
        List<Flight> GetFlight_s(int id = -1);
        bool CreateFlight(Flight flight);
        bool UpdateFlight(Flight flight);
        bool DeleteFlightById(int id);
    }
}
