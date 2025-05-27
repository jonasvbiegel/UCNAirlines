using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UCNAirlinesWebpage.Models;
using UCNAirlinesWebpage.ServiceLayer;

namespace UCNAirlinesWebpage.BusinesslogicLayer
{
    public class FlightLogic
    {
        private readonly IFlightAccess _flightServiceAccess;
        public FlightLogic()
        {
            _flightServiceAccess = new FlightServiceAccess();
        }

        public async Task<List<Flight>?> GetFlightsByDate(string date)
        {
            List<Flight>? foundFlights;
            try
            {
                foundFlights = await _flightServiceAccess.GetFlights(date);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving flights: {ex.Message}");
                foundFlights = null;
            }

            return foundFlights;
        }

        public async Task<Flight>? GetFlightById(int id)
        {
            Flight? foundFlight;
            try
            {
                foundFlight = await _flightServiceAccess.GetFlight(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving flights: {ex.Message}");
                foundFlight = null;
            }

            return foundFlight;
        }
        public async Task<FlightSearchModel> ReturnSelectedFlightsAsync(string from, string to, DateOnly date, int passenger)
        {
            var model = new FlightSearchModel
            {
                From = from,
                To = to,
                Date = date,
                Passenger = passenger
            };
            FlightServiceAccess fac = new FlightServiceAccess();
            List<Flight> fls = await fac.GetFlights(date.ToString());
            model.Flights = new List<Flight>();
            foreach (Flight f in fls)
            {
                if (model.From == f.Route.StartDestination.AirportName && model.To == f.Route.EndDestination.AirportName)
                {
                    model.Flights.Add(f);
                }
            }
            return model;

        }

    }

}

    
 
