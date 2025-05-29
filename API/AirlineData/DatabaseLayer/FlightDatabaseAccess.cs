using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AirlineData.ModelLayer;
using AirlineData.ModelViewDatabase;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace AirlineData.DatabaseLayer
{
    public class FlightDatabaseAccess : IFlight
    {
        private readonly string? _connectionString;

        public FlightDatabaseAccess(IConfiguration inConfig)
        {

            _connectionString = inConfig.GetConnectionString("CompanyConnection");
        }


        public bool CreateFlight(Flight flight)
        {

            string cmd = @"INSERT INTO Flight(airplane_id_FK, datetime, flight_route_id_FK) 

                         VALUES(@AirplaneId, @Departure, @FlightRouteId)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                int rowsAffected = con.Execute(cmd, new { AirplaneId = flight.Airplane.AirplaneId, Departure = flight.Departure, FlightRouteId = flight.Route.FlightRouteId });

                
                return rowsAffected > 0;
            }
        }
        public bool DeleteFlightById(int id)
        {
            string deleteFlightDb = "DELETE FROM Flight WHERE flight_id = @FlightId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                int rowsAffected = con.Execute(deleteFlightDb, new { FlightId = id });

                // Return true if at least one row is deleted; otherwise, false
                return rowsAffected > 0;
            }
        }


        private List<Seat> GetSeatsForFlight(int flightId)
        {
            string seatQuery = @"
        SELECT 
            seat_id, 
            seat_name, 
            passport_no_FK 
        FROM Seat 
        WHERE flight_id_FK = @FlightId";
             
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.Query<Seat>(seatQuery, new { FlightId = flightId }).ToList();
            }
        }



        public bool UpdateFlight(Flight flight)
        {
            string updateFlightDb = "UPDATE Flight SET datetime = @Departure, airplane_id_FK = @AirplaneId, flight_route_id_FK = @FlightRouteId WHERE flight_id = @FlightId";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                int rowsAffected = con.Execute(updateFlightDb, new
                {
                    FlightId = flight.FlightId,
                    Departure = flight.Departure,
                    AirplaneId = flight.Airplane.AirplaneId,
                    FlightRouteId = flight.Route.FlightRouteId
                });

                return rowsAffected > 0;
            }
        }


        private FlightRoute getFlightRoute(int id)
        {
            FlightRoute route = null;
            Airport airportStart = null;
            Airport airportEnd = null;
            string query = "SELECT *FROM RouteWithAirports WHERE FlightRouteId=@id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                RouteWithAirports? detailed = connection.QueryFirstOrDefault<RouteWithAirports>(query, new { id = id });
                if (detailed != null)
                {
                    airportStart = new()
                    {
                        IcaoCode = detailed.StartAirportCode,
                        AirportName = detailed.StartAirportName

                    };
                    airportEnd = new()
                    {
                        IcaoCode = detailed.EndAirportCode,
                        AirportName = detailed.EndAirportName
                    };
                    route = new()
                    {
                        FlightRouteId = detailed.FlightRouteId,
                        StartDestination = airportStart,
                        EndDestination = airportEnd
                    };
                }
                return route;
            }

        }

        public List<Flight> GetFlight_s(int id = -1)
        {
            List<Flight> flight_s = new List<Flight>();
            FlightRoute route = null;
            Airplane airplane = null;
            string query = "SELECT* FROM FlightRouteAirplane WHERE FlightId=@id";
            string query1 = "SELECT *FROM FlightRouteAirplane";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                if (id != -1)
                {
                    var detail = connection.QueryFirstOrDefault<FlightRouteAirplane>(query, new { id = id });
                    Flight f = PopulateObjectsBasedOnQueryView(detail);
                    flight_s.Add(f);
                }
                else
                {
                    var details = connection.Query<FlightRouteAirplane>(query1).ToList();
                    foreach (var detail in details)
                    {
                        Flight f = PopulateObjectsBasedOnQueryView(detail);
                        flight_s.Add(f);
                    }
                }
                return flight_s;
            }

        }

        private Flight PopulateObjectsBasedOnQueryView(FlightRouteAirplane fra)
        {
            FlightRoute route = getFlightRoute(fra.FlightRouteId);
            Airplane airplane = new()
            {
                AirplaneId = fra.AirplaneId,
                Airline = fra.Airline,
                SeatColumns = fra.SeatColumns,
                SeatRows = fra.SeatRows
            };
            Flight flight = new()
            {
                FlightId = fra.FlightId,
                Departure = fra.Departure,
                Airplane = airplane,
                Route = route,
                Seats = GetSeatsForFlight(fra.FlightId)
            };
            return flight;
        }

    }
}

