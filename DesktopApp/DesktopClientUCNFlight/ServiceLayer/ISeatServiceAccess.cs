using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.ServiceLayer
{
    internal interface ISeatServiceAccess
    {
        Task<List<Seat>?> GetSeatsForFlight(int flightId);
    }
}
