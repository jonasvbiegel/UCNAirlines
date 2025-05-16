using AirlineData.DatabaseLayer;

namespace APIService.BusinessLayer
{
    public class AirportLogic:IAirportLogic
    {
        private readonly IAirport _airportdb;
        public AirportLogic(IAirport airportdb)
        {
            _airportdb = airportdb;
        }

        public List<string> GetAllAirports()
        {
           return _airportdb.GetAllAirports();
        }
    }
}
