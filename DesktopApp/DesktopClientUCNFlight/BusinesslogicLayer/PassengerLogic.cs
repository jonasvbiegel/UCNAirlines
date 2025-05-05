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
        private readonly IPassengerServiceAccess _passengerServiceAccess;

        // Konstruktør til at initialisere PassengerServiceAccess
        public PassengerLogic()
        {
            _passengerServiceAccess = new PassengerServiceAccess(); // Initialiserer ServiceAccess til API'et
        }

        // Asynkron metode til at gemme en passager
        public async Task<bool> CreatePassenger(Passenger passenger)
        {
            try
            {
                // Kalder asynkront PassengerServiceAccess for at oprette passageren
                var createdPassenger = await _passengerServiceAccess.PostPassenger(passenger);

                // Hvis oprettelsen lykkes, returner true
                return createdPassenger != null;
            }
            catch (Exception ex)
            {
                // Hvis der sker en fejl, f.eks. hvis API'et er utilgængeligt, returner false
                // Det kan være nyttigt at logge fejlinformationen (ex.Message) i en rigtig applikation.
                Console.WriteLine($"Fejl ved oprettelse af passager: {ex.Message}");
                return false;
            }
        }
    }
}