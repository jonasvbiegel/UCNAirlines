using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AirlineData.ModelLayer
{
    public class Seat
    {
        public Seat(string seatName, bool isBooked)
        {
            Seat_name = seatName;
            Is_booked = isBooked;
        }

        public Seat(int seatId, string seatName, bool isBooked): this(seatName,isBooked)
        {
            SeatId = seatId;
            
        }
        [JsonIgnore]
        public int SeatId { get; set; }
        public string Seat_name { get; set; }
        public bool Is_booked { get; set; }
    }

}
