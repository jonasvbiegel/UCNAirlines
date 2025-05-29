using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public async Task<List<Seat>?> ConvertCookiesToPassengers(int passengerCount, IRequestCookieCollection cookies ) {
            SeatLogic sl = new SeatLogic(); 
            List<Seat> seats = new List<Seat>();
            for (int i = 0; i < passengerCount; i++)
            {
                string SDate = cookies[i + "Birthdate"];
                DateOnly date = DateOnly.Parse(SDate);
                Passenger passenger = new()
                {
                    FirstName = cookies[i + "FirstName"],
                    LastName = cookies[i + "LastName"],
                    PassportNo = cookies[i + "PassportNr"],
                    BirthDate = date
                };
                string Sseatid = cookies[i + "SeatId"];
                int seatId = int.Parse(Sseatid);
                Seat seat = await sl.GetSeatBySeatId(seatId);
                seat.Passenger = passenger;
                seats.Add(seat);
            }
            return seats;
        }
    }
}
