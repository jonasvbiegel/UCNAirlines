using AirlineData.ModelLayer;
using APIService.DTOs;

namespace APIService.ModelConversion
{
    public class AirportDTOConversion
    {
        public static List<AirportDTO>? FromAirportCollection(List<Airport> airs)
        {
            List<AirportDTO>? airsDTO = null;
            if (airs != null)
            {
                airsDTO = new List<AirportDTO>();
                AirportDTO tempDto;
                foreach (Airport a in airs)
                {
                    tempDto = FromAirport(a);
                    airsDTO.Add(tempDto);

                }
            }
            return airsDTO;
        }
        public static AirportDTO FromAirport(Airport a)
        {
            AirportDTO? aDto = null;
            if (a != null)
            {
                aDto = new AirportDTO()
                {
                    AirportName=a.AirportName,
                    Country=a.Country,  
                    City=a.City,    
                    Zipcode = a.Zipcode 

                };
            }
            return aDto;
        }


        public static Airport? ToAirport(AirportDTO aDto)
        {
            Airport? a = null;
            if (aDto != null)
            {
                a = new Airport()
                {
                    AirportName = aDto.AirportName,
                    City = aDto.City,
                    Country = aDto.Country, 
                    Zipcode = aDto.Zipcode
                    
                };

            }
            return a;
        }
    }
}