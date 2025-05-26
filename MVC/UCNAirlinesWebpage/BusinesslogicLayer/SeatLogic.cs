using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;

namespace UCNAirlinesWebpage.BusinesslogicLayer
{
    public class SeatLogic
    {
        private ISeatAccess _seatServiceAccess;
        public SeatLogic()
        {
            _seatServiceAccess = new SeatServiceAccess();
        }
        public async Task<List<Seat>?> GetSeatsForFlight(int flightId)
        {
            List<Seat>? seats;
            try
            {
                seats = await _seatServiceAccess.GetSeats(flightId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving seats: {ex.Message}");
                seats = null;
            }

            return seats;
        }
        public async Task<bool> UpdateSeats(List<Seat> seat)
        {
            try
            {
                return await _seatServiceAccess.TryUpdateSeats(seat);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating seat: {ex.Message}");
                return false;
            }
        }

        public async Task<Seat>? GetSeatBySeatId(int seatId)
        {
            Seat? seat;
            try
            {
                seat = await _seatServiceAccess.GetSeatBySeatID(seatId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving seats: {ex.Message}");
                seat = null;
            }

            return seat;
        }
    }
}
