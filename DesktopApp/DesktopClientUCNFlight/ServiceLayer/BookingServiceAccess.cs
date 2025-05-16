using DesktopClientUCNFlight.ModelLayer;
using Newtonsoft.Json;
using System.Text;


namespace DesktopClientUCNFlight.ServiceLayer
{
    public class BookingServiceAccess : ServiceConnection, IBookingAccess
    {
        public BookingServiceAccess() : base("https://localhost:7184/api/bookings/")
        {
        }
        public async Task<bool> InsertBooking(Booking booking)
        {
            bool b = false;
            UseUrl = BaseUrl;

            string bookingJson = JsonConvert.SerializeObject(booking);
            var httpContent = new StringContent(bookingJson, Encoding.UTF8, "application/json");
            var serviceResponse = await base.CallServicePost(httpContent);

            if (serviceResponse.IsSuccessStatusCode)
            {
                b = true;
            }

            return b;

        }

    }
}

