using AirlineData.ModelLayer;
using APIService.DTOs;

namespace APIService.ModelConversion
{
    public class SeatDTOConversion
    {
        public static List<Seat?> ToSeatCollection(List<SeatDTO> stsDTO)

        {
            List<Seat>? sts = null;
            if (stsDTO != null)
            {
                sts = new List<Seat>();
                Seat temp;
                foreach (SeatDTO sDTO in stsDTO)
                {
                    temp = ToSeat(sDTO);
                    sts.Add(temp);

                }
            }
            return sts;

        }

        public static Seat ToSeat(SeatDTO sDTO)
        {
            Seat? s = null;
            if (sDTO != null)
            {
                s = new Seat()
                {
                 SeatId=sDTO.SeatNumber,
                 SeatName=sDTO.SeatName,
                 Passenger=PassengerDTOConversion.ToPassenger(sDTO.Passenger)
                };

            }
            return s;
        }

        public static List<SeatDTO?> FromSeatCollection(List<Seat?>? sts)
        {
            List<SeatDTO>? stsDTO = null;
            if (sts != null)
            {
                stsDTO = new List<SeatDTO>();
                SeatDTO tempDTO;
                foreach (Seat s in sts)
                {
                    tempDTO = FromSeat(s);
                    stsDTO.Add(tempDTO);

                }
            }
            return stsDTO;
        }

        public static SeatDTO FromSeat(Seat? s)
        {
            SeatDTO? sDto = null;
            if (s != null)
            {

                sDto = new SeatDTO()
                {
                    SeatNumber=s.SeatId,
                    SeatName=s.SeatName,
                    Passenger=PassengerDTOConversion.FromPassenger(s.Passenger)
                };
            }
            return sDto;
        }

        
}
}
