using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;

namespace APIService.BusinessLayer;

public class PassengerLogic : IPassengerLogic
{

    private readonly IPassengerLogic _passengerLogic;

    public PassengerLogic(IPassengerLogic passengerLogic)
    {
        _passengerLogic = passengerLogic;
    }

    public Passenger? GetPassenger(string passportNo)
    {
        return _passengerLogic.GetPassenger(passportNo);
    }

    public Passenger? CreatePassenger(Passenger passenger)
    {
        return _passengerLogic.CreatePassenger(passenger);
    }
}
