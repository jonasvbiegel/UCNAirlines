using AirlineData.ModelLayer;
using APIService.DTOs;

namespace APIService.BusinessLayer;

public interface IPassengerLogic
{
    public PassengerDTO? GetPassenger(string passportNo);
    public Passenger? CreatePassenger(PassengerDTO passenger);
}
