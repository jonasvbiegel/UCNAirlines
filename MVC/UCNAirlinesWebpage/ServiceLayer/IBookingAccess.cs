using UCNAirlinesWebpage.Models;

namespace UCNAirlinesWebpage.ServiceLayer
{
    public interface IBookingAccess
    {
        public Task<bool> InsertBooking(Booking booking);
    }
}
