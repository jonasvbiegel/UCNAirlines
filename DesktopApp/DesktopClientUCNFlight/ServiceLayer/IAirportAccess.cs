namespace DesktopClientUCNFlight.ServiceLayer
{
    public interface IAirportAccess
    {
        Task<List<string>?> GetAirports();
    }
}
