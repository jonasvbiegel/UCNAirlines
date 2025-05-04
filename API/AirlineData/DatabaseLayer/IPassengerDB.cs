using AirlineData.ModelLayer;

namespace AirlineData.DatabaseLayer;

public interface IPassengerDB
{
    public Passenger? GetPassenger(string passportNo);
    public Passenger? CreatePassenger(Passenger passenger);
}
