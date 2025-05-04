using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;
using DesktopClientUCNFlight.ServiceLayer;

namespace DesktopClientUCNFlight.BusinesslogicLayer
{
    public class PassengerLogic
    {
        private IPassengerServiceAccess _serviceAccess;

        public PassengerLogic()
        {
            _serviceAccess = new PassengerServiceAccess(); // senere kan det være API
        }

        public Passenger CreatePassenger(string passportNo, string firstName, string lastName, DateOnly birthDate)
        {
            Passenger passenger = new Passenger();
            passenger.PassportNo = passportNo;
            passenger.FirstName = firstName;
            passenger.LastName = lastName;
            passenger.BirthDate = birthDate;

            // Kald til service-laget (dummy nu, API senere)
            return _serviceAccess.SavePassenger(passenger);
        }
    }
}