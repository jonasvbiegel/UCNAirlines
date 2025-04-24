using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer
{
    public class FlightDatabaseAccess
    {
       // Seat a { get; }
       //Seat seat1 = new() { SeatName = "1A", IsBooked = true };
       // Seat seat2 = new() { SeatName = "1B", IsBooked = true };
       // Seat seat3 = new() { SeatName = "1C", IsBooked = false };
       // Seat seat4 = new() { SeatName = "1D", IsBooked = true };
       // Seat seat5 = new() { SeatName = "1E", IsBooked = false };
       // Seat seat6 = new() { SeatName = "1F", IsBooked = true };
       // Seat seat7 = new() { SeatName = "2A", IsBooked = false };
       // Seat seat8 = new() { SeatName = "3A", IsBooked = true };
       // Seat seat9 = new() { SeatName = "4A", IsBooked = true };

        List<Seat> seatList { get; }
        

        public FlightDatabaseAccess()
        {
            //string airplaneId, string model, int capacity, char seatColumns, int seatRows
            Airplane airplane1 = new("1", "UCNDK787", 8,4,2);
            Airplane airplane2 = new("2", "UCNdfjds",6 , 3, 2);

            Seat seat1 = new() { SeatName = "1A", IsBooked = true };
            Seat seat2 = new() { SeatName = "1B", IsBooked = true };
            Seat seat3 = new() { SeatName = "1C", IsBooked = false };
            Seat seat4 = new() { SeatName = "1D", IsBooked = true };
            Seat seat5 = new() { SeatName = "2A", IsBooked = false };
            Seat seat6 = new() { SeatName = "2B", IsBooked = true };
            Seat seat7 = new() { SeatName = "2C", IsBooked = false };
            Seat seat8 = new() { SeatName = "2D", IsBooked = true };
            //Seat seat9 = new() { SeatName = "4A", IsBooked = true };
            seatList = new() { seat1, seat2, seat3, seat4, seat5, seat6, seat7, seat8 };
            FlightRoute flightRoute1 = new() { DepartureAirport = "Copenhagen", ArrivalAirport = "Nuuk" };
            DateTime departureDate1 = new DateTime(2025, 10, 1, 14, 30, 0);
            DateTime departureDate2 = new DateTime(2025, 10, 5, 16, 30, 0);

            Flight flight1=new() { Departure = departureDate1, ListOfSeats = seatList, airplane = airplane1, route = flightRoute1 };  
            Flight flight2=new() { Departure = departureDate2, ListOfSeats = seatList, airplane = airplane2, route = flightRoute1 };
        }
}
}

