namespace UCNAirlinesWebpage.ServiceLayer
{
    public class PassengerServiceAccess : ServiceConnection, IPassengerAccess
    {
        public PassengerServiceAccess() : base("https://localhost:7184/api/passengers/")
        {

        }
    }
}
