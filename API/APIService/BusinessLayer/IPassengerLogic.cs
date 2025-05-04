using AirlineData.ModelLayer;

namespace APIService.BusinessLayer;

public interface IPassengerLogic
{
    public Passenger? GetPassenger(string passportNo);
    public Passenger? CreatePassenger(Passenger passenger);
}
