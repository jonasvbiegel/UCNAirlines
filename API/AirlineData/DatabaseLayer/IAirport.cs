using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineData.DatabaseLayer
{
    public interface IAirport
    {
        public List<string> GetAllAirports();
    }
}
