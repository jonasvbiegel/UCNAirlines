using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;

namespace APIService.BusinessLayer;

public class PassengerLogic : IPassengerLogic
{

    private readonly IPassengerDB _passengerDB;

    public PassengerLogic(IPassengerDB passengerDB)
    {
        _passengerDB = passengerDB;
    }

    public Passenger? GetPassenger(string passportNo)
    {
        return _passengerDB.GetPassenger(passportNo);
    }

    public Passenger? CreatePassenger(Passenger passenger)
    {
        return _passengerDB.CreatePassenger(passenger);
    }
}
