using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public interface IBookingAccess
    {
        Task<bool> InsertBooking(Booking booking);
    }
}
