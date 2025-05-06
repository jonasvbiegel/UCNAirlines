using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;

namespace Testservicelayer
{
    public class ServicelayerTest
    {

        [Fact]
        public async void Test1()
        { SeatServiceAccess ssa=new SeatServiceAccess();
            Passenger p = new() { PassportNo = "87654321", FirstName = "Hans", LastName = "Hansen" }; 
            Seat seat = new() { SeatId = 3, SeatName = "2A", Passenger = p };
            bool b=await ssa.UpdateSeat(seat); 
            Assert.True(b);
        }
    }
}