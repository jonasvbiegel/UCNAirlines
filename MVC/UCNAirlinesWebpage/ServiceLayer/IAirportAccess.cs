namespace UCNAirlinesWebpage.ServiceLayer
{
    public interface IAirportAccess
    {
        Task<List<string>?> GetAirports();
    }
}
