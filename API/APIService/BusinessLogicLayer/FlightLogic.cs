using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using APIService.DTOs;
using APIService.ModelConversion;

namespace AirlineData.BusinessLayer
{
    public class FlightLogic
    {
        private readonly IFlightDatabaseAccess _flightAccess;

        public FlightLogic(IFlightDatabaseAccess flightAccess)
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
            }
            catch
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
                flightDTO = FlightDTOConvert.FromFlight(flight);
            }
            catch
            {
                flightDTO = null;
            }
            return flightDTO;
        }

        public List<FlightDTO> Get(DateTime date)
        {
            List<FlightDTO> flightsDTO;
            try
            {
                List<Flight> flights = _flightAccess.GetAllFlightsByDate(date);
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

