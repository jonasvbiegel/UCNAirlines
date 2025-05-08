using AirlineData.ModelLayer;
using APIService.DTOs;
using Microsoft.AspNetCore.Routing;
using System.Runtime.Intrinsics.X86;

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
        // Convert from Person object to PersonDTO object
        public static FlightDTO FromFlight(Flight flight)
        {
            FlightDTO? flightDto = null;
            if (flight != null)
            {
                flightDto = new FlightDTO(flight.Departure, flight.Airplane, flight.Route);
            }
            return flightDto;
        }

        // Convert from PersonDTO object to Person object
        public static Flight? ToFlight(FlightDTO flightDto)
        {
            Flight? flight = null;
            if (flightDto != null)
            {
                flight = new Flight()
                {
                    Departure = flightDto.Departure_time_and_date,
                    Airplane = flightDto.Airplane,
                    Route = flightDto.Route,
                    Seats = flightDto.Seats
                };
            }

            return flight;
        }

    }
}

