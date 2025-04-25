using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using FlightRestService.DTOs;
using FlightRestService.ModelConversion;
using Microsoft.AspNetCore.Identity;

namespace FlightRestService.BusinessLogicLayer
{
    public class FlightDataLogic : IFlightData
    {
        private readonly IFlight _flightAccess;

        public FlightDataLogic(IFlight flightAccess)
        {
            _flightAccess = flightAccess;
        }
        

        public int Create(FlightDTO flightAdd)
        {
            int insertedId = 0;
            try
            {
                Flight? dbFlight = FlightDTOConvert.ToFlight(flightAdd);

                if (dbFlight != null)
                {
                    insertedId = _flightAccess.CreateFlight(dbFlight);
                }
            }catch
            {
                insertedId = -1;
            }
            return insertedId;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FlightDTO? Get(int id)
        {
            FlightDTO flightDTO;
            try
            {
                Flight flight = _flightAccess.GetFlightById(id);
                flightDTO=FlightDTOConvert.FromFlight(flight);
            }
            catch
            {
                flightDTO = null;
            }
           return flightDTO;
        }

        public List<FlightDTO> Get()
        {
            List<FlightDTO> flightsDTO;
            try {
                List<Flight> flights = _flightAccess.GetAllFlights();
                flightsDTO = FlightDTOConvert.FromFlightCollection(flights);
            }
            catch
            {
                flightsDTO = null;
            }
            return flightsDTO;
            }

        public bool Update(FlightDTO flightUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
