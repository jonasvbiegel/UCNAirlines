using APIService.DTOs;

namespace APIService.BusinessLayer
{
    public interface IFlightLogic
    {
        List<FlightDTO?>? GetByDate(DateOnly date);
        FlightDTO? GetById(int id);
        bool Delete(int id);

    }
}
