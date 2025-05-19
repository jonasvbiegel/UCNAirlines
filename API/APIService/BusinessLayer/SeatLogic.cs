using APIService.BusinessLayer;
using AirlineData.DatabaseLayer;
using AirlineData.ModelLayer;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using APIService.DTOs;
using APIService.ModelConversion;

namespace APIService.BusinessLayer;

public class SeatLogic : ISeatLogic
{

    private readonly string _connectionString = "Data Source = localhost; Initial Catalog = UCNAirlines; Persist Security Info=True; User ID = sa; Password=@12tf56so; Encrypt=False";

    private readonly ISeatDB _seatDB;

    public SeatLogic(ISeatDB seatDB)
    {
        _seatDB = seatDB;
    }

    public List<SeatDTO?>? GetSeats()
    {
        List<SeatDTO?> stsDTO = SeatDTOConversion.FromSeatCollection(_seatDB.GetAllSeats() ?? null);
        return stsDTO;
    }

    public List<SeatDTO?>? GetSeatsFromFlight(int flightId)
    {
        List<SeatDTO?> stsDTO=new List<SeatDTO?>();
        if (flightId > 0)
        {
           stsDTO = SeatDTOConversion.FromSeatCollection(_seatDB.GetSeatsFromFlight(flightId) ?? null);
        }
            return stsDTO;
    }

    public SeatDTO? GetSeat(int seatId)
    {
        SeatDTO? stsDTO = null;
        if (seatId > 0)
        {
           stsDTO = SeatDTOConversion.FromSeat(_seatDB.GetSeat(seatId) ?? null);
        }
            return stsDTO;
    }

    public bool TryBookSeats(List<SeatDTO?>? stsDTO)
    {
        List<Seat> seats = new List<Seat>();      
        if(stsDTO != null)
        {
            seats=SeatDTOConversion.ToSeatCollection(stsDTO);
        }  
        return _seatDB.TryUpdateSeats(seats);
    }

    public bool UpdateSeat(SeatDTO sdto)
    {
        Seat seat = SeatDTOConversion.ToSeat(sdto);

        try
        {
            _seatDB.UpdateSeat(seat);
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return true;
    }
}
