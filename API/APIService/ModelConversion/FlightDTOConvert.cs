using AirlineData.ModelLayer;
using APIService.DTOs;
using Microsoft.AspNetCore.Routing;

namespace APIService.ModelConversion
{
    public class FlightDTOConvert
    {
        public static List<FlightDTO>? FromFlightCollection(List<Flight> flights)
        {
            List<FlightDTO>? flightsDTO = null;
            if (flights != null)
            {
                flightsDTO = new List<FlightDTO>();
                FlightDTO tempDto;
                foreach (Flight f in flights)
                {
                    tempDto = FromFlight(f);
                    flightsDTO.Add(tempDto);

                }
            }
            return flightsDTO;
        }
     
        public static FlightDTO FromFlight(Flight flight)
        {
            FlightDTO? flightDto = null;
            if (flight != null)
            {
                flightDto = new FlightDTO(flight.Departure, AirplaneDTOConversion.FromAirplane(flight.Airplane), FlightRouteDTOConversion.FromFlightRoute(flight.Route), flight.FlightId);
            }
            return flightDto;
        }

     
        public static Flight? ToFlight(FlightDTO flightDto)
        {
            Flight? flight = null;
            if (flightDto != null)
            {
                flight = new Flight()
                {
                    Departure = flightDto.Departure_time_and_date,
                    Airplane = AirplaneDTOConversion.ToAirplane(flightDto.Airplane),
                    Route = FlightRouteDTOConversion.ToFlightRoute(flightDto.Route),
                    Seats = SeatDTOConversion.ToSeatCollection(flightDto.Seats)
                    
                };
            }

            return flight;
        }

    }
}

