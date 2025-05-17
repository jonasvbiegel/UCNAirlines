using AirlineData.ModelLayer;
using APIService.DTOs;

namespace APIService.ModelConversion
{
    public class AirplaneDTOConversion
    {
        
       
        public static AirplaneDTO FromAirplane(Airplane a)
        {
            AirplaneDTO? aDto = null;
            if (a != null)
            {
                aDto = new AirplaneDTO()
                {
                    Airplane_number = a.AirplaneId,
                    Airline = a.Airline,
                    ColumnCount = a.SeatColumns,
                    RowCount = a.SeatRows,

                };
            }
            return aDto;
        }


        public static Airplane? ToAirplane(AirplaneDTO aDto)
        {
            Airplane? a = null;
            if (aDto != null)
            {
                a = new Airplane()
                {
                    AirplaneId=aDto.Airplane_number,
                    Airline = aDto.Airline,
                    SeatRows=aDto.RowCount,
                    SeatColumns=aDto.ColumnCount
                };
           
        }
            return a;
        }

    }
}

