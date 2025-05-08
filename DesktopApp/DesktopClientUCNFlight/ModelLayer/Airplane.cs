using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClientUCNFlight.ModelLayer
{
    public class Airplane
    {
        public string? AirplaneId { get; set; }
        public string? Airline { get; set; }
        public int Capacity
        {
            get
            {
                return SeatRows * SeatColumns;
            }
        }
        public int SeatRows { get; set; }
        public int SeatColumns { get; set; }
    }
}
