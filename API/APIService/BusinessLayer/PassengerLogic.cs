using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using APIService.DTOs;
using APIService.ModelConversion;

namespace APIService.BusinessLayer;

public class PassengerLogic : IPassengerLogic
{

    private readonly IPassengerDB _passengerDB;

    public PassengerLogic(IPassengerDB passengerDB)
    {
        _passengerDB = passengerDB;
    }

    public PassengerDTO? GetPassenger(string passportNo)
    {
        PassengerDTO pDTO = PassengerDTOConversion.FromPassenger(_passengerDB.GetPassenger(passportNo));
        return pDTO;
    }

    public Passenger? CreatePassenger(PassengerDTO passengerDto)
    {
        Passenger passenger = PassengerDTOConversion.ToPassenger(passengerDto);
        return _passengerDB.CreatePassenger(passenger);
    }
}
