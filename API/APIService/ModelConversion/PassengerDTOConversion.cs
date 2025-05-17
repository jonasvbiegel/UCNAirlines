using AirlineData.ModelLayer;
using APIService.DTOs;

namespace APIService.ModelConversion
{
    public class PassengerDTOConversion
    {
        public static List<PassengerDTO?> FromPassengerCollection(List<Passenger?>? ps)
        {
            List<PassengerDTO>? psDTO = null;
            if (ps != null)
            {
                psDTO = new List<PassengerDTO>();
                PassengerDTO tempDTO;
                foreach (Passenger p in ps)
                {
                    tempDTO = FromPassenger(p);
                    psDTO.Add(tempDTO);

                }
            }
            return psDTO;
        }

        public static PassengerDTO FromPassenger(Passenger? p)
        {
            PassengerDTO? pDto = null;
            if (p != null)
            {

                pDto = new PassengerDTO()
                {
                    PassportNo = p.PassportNo,
                    BirthDate = p.BirthDate,
                    FirstName = p.FirstName,
                    LastName = p.LastName
                };
            }
            return pDto;
        }

        public static List<Passenger?> ToPassengerCollection(List<PassengerDTO?>? psDTO)
        {
            List<Passenger>? ps = null;
            if (psDTO != null)
            {
                ps = new List<Passenger>();
                Passenger temp;
                foreach (PassengerDTO pDTO in psDTO)
                {
                    temp = ToPassenger(pDTO);
                    ps.Add(temp);

                }
            }
            return ps;
        }

        public static Passenger ToPassenger(PassengerDTO? pDTO)
        {
            Passenger? p = null;
            if (pDTO != null)
            {
                p = new Passenger()
                {
                    PassportNo= pDTO.PassportNo,
                    BirthDate = pDTO.BirthDate,
                    FirstName = pDTO.FirstName,
                    LastName = pDTO.LastName    
                };

            }
            return p;
        }

        
    }
}

