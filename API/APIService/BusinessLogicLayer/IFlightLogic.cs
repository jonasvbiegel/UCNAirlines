using APIService.DTOs;

namespace APIService.BusinessLogicLayer
{
    public interface IFlightLogic
    {
        List<FlightDTO?>? GetByDateAndTime(DateTime date);
        int Create(FlightDTO flightAdd);
        bool Update(FlightDTO flightUpdate);
        bool Delete(int id);
     
    }
}
