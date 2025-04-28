using FlightRestService.DTOs;

namespace FlightRestService.BusinessLogicLayer
{
    public interface IFlightData
    {
        FlightDTO? Get(int id);
        List<FlightDTO?>? Get(DateTime date);
        int Create(FlightDTO flightAdd);
        bool Update(FlightDTO flightUpdate);
        bool Delete(int id);

    }
}
