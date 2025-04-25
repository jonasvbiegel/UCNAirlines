using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineData.ModelLayer
{
    public class Seat
    {
        public Seat(string seatName, bool isBooked)
        {
            SeatName = seatName;
            IsBooked = isBooked;
        }

        public Seat(int seatId, string seatName, bool isBooked): this(seatName,isBooked)
        {
            SeatId = seatId;
            
        }

        public int SeatId { get; set; }
        public string SeatName { get; set; }
        public bool IsBooked { get; set; }
    }

}
