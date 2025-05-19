using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClientUCNFlight.ModelLayer
{
    public class Airplane
    {
        public string? Airplane_number { get; set; }
        public string? Airline { get; set; }
        public int Capacity
        {
            get
            {
                return RowCount * ColumnCount;
            }
        }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
    }
}
