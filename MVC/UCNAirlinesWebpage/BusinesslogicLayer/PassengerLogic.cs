using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;

namespace UCNAirlinesWebpage.BusinesslogicLayer
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

                wasCreated = (createdPassenger != null);
            }
            catch (Exception ex)
            {
                wasCreated = false;
            }
            return wasCreated;
        }
    }
}
