using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using APIService.DTOs;
using APIService.ModelConversion;
using Microsoft.Data.SqlClient;

namespace APIService.BusinessLayer
{
    public class FlightLogic : IFlightLogic
    {
        private readonly IFlight _flightAccess;

        public FlightLogic(IFlight flightAccess)
        {
            _flightAccess = flightAccess;
        }


        public bool Create(FlightDTO flightAdd)
        {
            bool insertedId = false;
            Flight? dbFlight = FlightDTOConvert.ToFlight(flightAdd);


            return _flightAccess.CreateFlight(dbFlight);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FlightDTO? GetById(int id)
        {
            FlightDTO flightDTO=null;
            try
            {
                Flight? flight = _flightAccess.GetFlight_s(id).FirstOrDefault();
                flightDTO = FlightDTOConvert.FromFlight(flight);
            }
            catch(SqlException  ex)   
            {
                Console.WriteLine(ex.Message); 
            }
            return flightDTO;
        }

        public List<FlightDTO>? GetByDate(DateOnly date)
        {
            List<FlightDTO> flightsByDate = new List<FlightDTO>();
            List<Flight> flights = _flightAccess.GetFlight_s();
            List<FlightDTO> flightsDTO = FlightDTOConvert.FromFlightCollection(flights);
            foreach (var flight in flightsDTO)
            {
                if ((DateOnly.FromDateTime(flight.Departure_time_and_date).Equals(date)))
                {
                    flightsByDate.Add(flight);
                }
            }


            return flightsByDate;
        }

        public bool Update(FlightDTO flightUpdate)
        {
            throw new NotImplementedException();
        }

        int IFlightLogic.Create(FlightDTO flightAdd)
        {
            throw new NotImplementedException();
        }
    }
}



