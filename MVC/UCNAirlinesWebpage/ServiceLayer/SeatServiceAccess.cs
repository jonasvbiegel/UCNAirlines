namespace UCNAirlinesWebpage.ServiceLayer
{
    public class SeatServiceAccess : ServiceConnection, ISeatAccess
    {
        public SeatServiceAccess() : base("https://localhost:7184/api/seats/")
        {
        }
    }
}
