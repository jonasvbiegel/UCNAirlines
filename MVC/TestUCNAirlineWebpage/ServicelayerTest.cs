using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;

namespace Testservicelayer
{
    public class ServicelayerTest
    {

        [Fact]
        public async void SeatGetTest()
        { SeatServiceAccess ssa=new SeatServiceAccess();
            Passenger p = new() { PassportNo = "87654321", FirstName = "Hans", LastName = "Hansen" }; 
            Seat seat = new() { SeatId = 3, SeatName = "2A", Passenger = p };
            List<Seat> seats = new();
            seats.Add(seat);
            bool b = await ssa.TryUpdateSeats(seats);
            Assert.True(b);
        }
        public async void PassengerCreateTest()
        {
            PassengerServiceAccess psa=new PassengerServiceAccess();
            Passenger p = new()
            {
                PassportNo = "0987654",
                FirstName="Liam",
                LastName="Nesson",
                
            };
            Passenger l=await psa.InsertPassenger(p);
            Assert.Equal(p, l);
        }

        public async void PassengerGetTest()
        {
            Passenger? p;
            PassengerServiceAccess psa = new PassengerServiceAccess();
            p = await psa.GetPassenger("12345678");
            Assert.NotNull(p);
            Assert.Equal(p.FirstName, "John");
        }

        public async void BookingCreate()
        {
            Passenger p = new()
            {
                PassportNo = "0987654",
                FirstName = "Liam",
                LastName = "Nesson",

            };
            List<Passenger> psg= new List<Passenger>();
            psg.Add(p);
            DateTime dateTime = new DateTime(2025, 1, 6, 12, 0, 0, 0);
            Flight f = new()
            {
                FlightId=3,
                Departure=dateTime
                

            };
            Booking booking = new()
            {
                Flight = f,
                passengers = psg
            };
            BookingServiceAccess bsa = new BookingServiceAccess();
            bsa.InsertBooking(booking);
        }

        [Fact]
        public async void TestGetAirports()
        {
            List<string> airports= new List<string>();
            AirportServiceAccess air= new AirportServiceAccess();
            airports = await air.GetAirports();
            Assert.Equal(5, airports.Count);
        }
    }
}