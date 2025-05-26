using AirlineData.ModelLayer;
using APIService.DTOs;

namespace APIService.ModelConversion
{
    public class FlightRouteDTOConversion
    {
        public static FlightRouteDTO FromFlightRoute(FlightRoute? route)
        {
            FlightRouteDTO? frDto = null;
            if (route != null)
            {

                frDto = new FlightRouteDTO()
                {
                    EndDestination = AirportDTOConversion.FromAirport(route.EndDestination),
                    StartDestination = AirportDTOConversion.FromAirport(route.StartDestination),
                    FlightRouteId = route.FlightRouteId
                };
            }
            return frDto;
        }


        public static FlightRoute ToFlightRoute(FlightRouteDTO rDTO)
        {
            FlightRoute? fd = null;
            if (rDTO != null)
            {
                fd = new FlightRoute()
                {
                    StartDestination = AirportDTOConversion.ToAirport(rDTO.StartDestination),
                    EndDestination = AirportDTOConversion.ToAirport(rDTO.EndDestination)
                };

            }
            return fd;
        }

    }
        
}
