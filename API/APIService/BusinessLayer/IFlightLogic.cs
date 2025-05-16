using APIService.DTOs;

namespace APIService.BusinessLayer
{
    public interface IFlightLogic
    {
        List<FlightDTO?>? GetByDate(DateOnly date);
        FlightDTO? GetById(int id);
        int Create(FlightDTO flightAdd);
        bool Update(FlightDTO flightUpdate);
        bool Delete(int id);

    }
}
