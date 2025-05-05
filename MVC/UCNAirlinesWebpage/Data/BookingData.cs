using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.Data
{
    public class BookingData
    {
        public static List<Booking> BookingList = new List<Booking>
        {
            new Booking { BookingId = 1, Passengers = new List<Passenger> { PassengerData.PassengerList[0], PassengerData.PassengerList[1] }, Flight = FlightData.FlightList[0] },
            new Booking { BookingId = 2, Passengers = new List<Passenger> { PassengerData.PassengerList[2] }, Flight = FlightData.FlightList[1] },
        };

        // Create
        public static void Create(Booking booking)
        {
            BookingList.Add(booking);
        }

        public static Booking? GetById(int bookingId)
        {
            return BookingList.FirstOrDefault(b => b.BookingId == bookingId);
        }
    }
}
