using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineData.ModelLayer;
using Microsoft.Identity.Client;

namespace AirlineData.DatabaseLayer
{
    public class BookingDatabaseAccess
    {
        public List<Flight> flights { get; set; }
        public List<Passenger> passengers { get; set; }
        public List<Booking> bookings { get; set; }
        public List<PassengerBooking> passengerBookings { get; set; }
      
        public BookingDatabaseAccess() 
        {

            Airplane airplane = new() { AirplaneId = "UCN123", Airline = "UCN", SeatRows = 20, SeatColumns = 4 };
            DateTime departure = DateTime.Parse("2025-01-06 10:00:00");
            Airport airport1 = new() { AirportName = "Aalborg" };
            Airport airport2 = new() { AirportName = "Nuuk" };
            FlightRoute flightRoute = new() { FlightRouteId = 1, StartDestination = airport1, EndDestination = airport2 };
            
            Flight flight = new() { Airplane = airplane, Departure = departure, Route = flightRoute };
            flights = new() { flight };

            Passenger ps1 = new() { PassportNo = "KD010100", FirstName = "Khanh", LastName = "Do", BirthDate = DateOnly.Parse("01-01-2000") };
            Passenger ps2 = new() { PassportNo = "RM020200", FirstName = "Rosa", LastName = "Mangoratass", BirthDate = DateOnly.Parse("02-02-2000") };
            Passenger ps3 = new() { PassportNo = "CM030300", FirstName = "Carmen", LastName = "Mihut", BirthDate = DateOnly.Parse("03-03-2000") };
            Passenger ps4 = new() { PassportNo = "AD040400", FirstName = "Anna", LastName = "Dinh", BirthDate = DateOnly.Parse("04-04-2000") };
            Passenger ps5 = new() { PassportNo = "JV050500", FirstName = "Jonas", LastName = "Vittrup", BirthDate = DateOnly.Parse("05-05-2000") };

            passengers = new() { ps1, ps2, ps3, ps4, ps5};

            Booking booking1 = new() { BookingId = 1, Flight = flight };
            Booking booking2 = new() { BookingId = 2, Flight = flight };
            Booking booking3 = new() { BookingId = 3, Flight = flight };

            bookings = new() { booking1, booking2, booking3 };

            PassengerBooking pB1 = new() { Passenger = ps1, Booking = booking1 };
            PassengerBooking pB2 = new() { Passenger = ps2, Booking = booking2 };
            PassengerBooking pB3 = new() { Passenger = ps3, Booking = booking3 };
        
            passengerBookings = new() { pB1,  pB2, pB3 };

        }

        public List<Booking> Get()
        {
            return bookings;
        }
    }
}
