using APIService.DTOs;

namespace APIService.BusinessLogicLayer
{
    public interface IFlightLogic
    {
        FlightDTO? Get(int id);
        List<FlightDTO?>? Get(DateTime date);
        int Create(FlightDTO flightAdd);
        bool Update(FlightDTO flightUpdate);
        bool Delete(int id);
    }
}
