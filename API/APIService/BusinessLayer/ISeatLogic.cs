namespace APIService.BusinessLayer;
using AirlineData.ModelLayer;
using APIService.DTOs;

public interface ISeatLogic
{
    public List<SeatDTO?>? GetSeats();
    public List<SeatDTO?>? GetSeatsFromFlight(int flightId);
    public SeatDTO? GetSeat(int seatId);
    public bool UpdateSeat(SeatDTO seat);
    public bool TryBookSeats(List<SeatDTO> seats);
}
