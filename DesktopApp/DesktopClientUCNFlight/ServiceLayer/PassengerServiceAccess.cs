using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClientUCNFlight.ModelLayer;

namespace DesktopClientUCNFlight.ServiceLayer
{
    public class PassengerServiceAccess : IPassengerServiceAccess
    {
        private static List<Passenger> _passengerDatabase = new List<Passenger>();

        public Passenger SavePassenger(Passenger passenger)
        {
            // Dummy: Gemmer passageren i en liste som "falsk database"
            _passengerDatabase.Add(passenger);

            // Returnér samme passager som bekræftelse
            return passenger;
        }
    }
}