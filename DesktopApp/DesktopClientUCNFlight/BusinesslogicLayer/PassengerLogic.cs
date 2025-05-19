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
        private readonly IPassengerAccess _passengerServiceAccess;

        public PassengerLogic()
        {
            _passengerServiceAccess = new PassengerServiceAccess();
        }

        public async Task<bool> CreatePassenger(Passenger passenger)
        {
            bool wasCreated = false;

            try
            {
                var createdPassenger = await _passengerServiceAccess.InsertPassenger(passenger);

<<<<<<< HEAD
                wasCreated = (createdPassenger != null);
=======
                wasCreated = (createdPassenger!=null);
>>>>>>> develop
            }
            catch (Exception ex)
            {
                wasCreated = false;
            }
            return wasCreated;
        }
    }
}
