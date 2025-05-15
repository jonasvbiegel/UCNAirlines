using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.ServiceLayer
{
    public interface IFlightServiceAccess
    {
        Task<List<Flight>?> GetFlightsByDate(DateOnly date);
        //void SelectSeatsForFlight(Flight flight, List<Seat> seats);
    }
}
