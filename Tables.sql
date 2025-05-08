USE UCNAirlines;

DROP VIEW IF EXISTS AirportZipCountry, FlightRouteAirplane, RouteWithAirports;

DROP TABLE IF EXISTS PassengerBooking, Seat, Passenger, Booking, Flight, Flight_Route, Airport, Airplane, City_Zip_Code, Country;

CREATE TABLE Country (
    country_id INT IDENTITY(1,1) PRIMARY KEY,
    country VARCHAR(128) NOT NULL
)

CREATE TABLE City_Zip_Code (
    zipcode VARCHAR(16) NOT NULL PRIMARY KEY,
    city VARCHAR(32) NOT NULL,
    country_id_FK INT FOREIGN KEY REFERENCES Country(country_id)
);

CREATE TABLE Airplane (
    airplane_id VARCHAR(128) NOT NULL PRIMARY KEY,
    airline VARCHAR(128) NOT NULL,
    seat_rows INT NOT NULL,
    seat_columns INT NOT NULL
);

CREATE TABLE Airport (
    icao_code VARCHAR(16) NOT NULL PRIMARY KEY,
    airport_name VARCHAR(128) NOT NULL,
    zipcode_FK VARCHAR(16) FOREIGN KEY REFERENCES City_Zip_Code(zipcode)
);

CREATE TABLE Flight_Route (
    flight_route_id INT IDENTITY(1,1) PRIMARY KEY,
    start_destination_FK VARCHAR(16) FOREIGN KEY REFERENCES Airport(icao_code),
    end_destination_FK VARCHAR(16) FOREIGN KEY REFERENCES Airport(icao_code),
    CHECK (start_destination_FK <> end_destination_FK),
    unique(start_destination_FK, end_destination_FK)
);

CREATE TABLE Flight (
    flight_id INT IDENTITY(1,1) PRIMARY KEY,
    departure DATETIME NOT NULL,
    airplane_id_FK VARCHAR(128) FOREIGN KEY REFERENCES Airplane(airplane_id),
    flight_route_id_FK INT FOREIGN KEY REFERENCES Flight_Route(flight_route_id)
);

CREATE TABLE Booking (
    booking_id INT IDENTITY(1,1) PRIMARY KEY,
    flight_id_FK INT FOREIGN KEY REFERENCES Flight(flight_id),
);

CREATE TABLE Passenger (
    passport_no VARCHAR(128) NOT NULL PRIMARY KEY,
    first_name VARCHAR(64) NOT NULL,
    last_name VARCHAR(64) NOT NULL,
    birth_date DATE NOT NULL,
);

-- CREATE TABLE Seat (
--     seat_id INT IDENTITY(1,1) PRIMARY KEY,
--     seat_name VARCHAR(128) NOT NULL,
--     passport_no_FK VARCHAR(128) FOREIGN KEY REFERENCES Passenger(passport_no),
--     flight_id_FK INT NOT NULL FOREIGN KEY REFERENCES Flight(flight_id),
-- );

CREATE TABLE Seat (
    seat_id INT IDENTITY(1,1) PRIMARY KEY,
    seat_name VARCHAR(128) NOT NULL,
    passport_no_FK VARCHAR(128) FOREIGN KEY REFERENCES Passenger(passport_no),
    flight_id_FK INT NOT NULL FOREIGN KEY REFERENCES Flight(flight_id),
    row_version rowversion
);

CREATE TABLE PassengerBooking (
    passenger_booking_id INT IDENTITY(1,1) PRIMARY KEY,
    booking_id_FK INT NOT NULL FOREIGN KEY REFERENCES Booking(booking_id),
    passport_no_FK VARCHAR(128) NOT NULL FOREIGN KEY REFERENCES Passenger(passport_no)
)

CREATE VIEW AirportZipCountry AS
SELECT
    airport.icao_code AS icaoCode,
    airport.airport_name AS airportName,
    airport.zipcode_FK AS airportZipcode,
    cityzip.city AS airportCity,
    country.country AS airportCountry
FROM Airport airport
         JOIN City_Zip_Code cityzip ON airport.zipcode_FK = cityzip.zipcode
         JOIN Country country ON cityzip.country_id_FK = country.country_id;
GO;

CREATE VIEW RouteWithAirports AS
SELECT
    r.flight_route_id AS FlightRouteId,
    r.start_destination_FK AS StartAirportCode,       -- Code from FlightRoute for the start airport
    r.end_destination_FK AS EndAirportCode,          -- Code from FlightRoute for the end airport

    sa.airportName AS StartAirportName,
    sa.airportZipcode AS StartAirportZipcode,
    sa.airportCity AS StartAirportCity,
    sa.airportCountry AS StartAirportCountry,

    ea.airportName AS EndAirportName,
    ea.airportZipcode AS EndAirportZipcode,
    ea.airportCity AS EndAirportCity,
    ea.airportCountry AS EndAirportCountry

FROM Flight_Route r
         JOIN AirportZipCountry sa ON r.start_destination_FK = sa.icaoCode
         JOIN AirportZipCountry ea ON r.end_destination_FK = ea.icaoCode;
GO;

CREATE VIEW FlightRouteAirplane AS
SELECT 
    f.flight_id AS FlightId, 
    f.departure AS Departure,
    a.airplane_id AS AirplaneId, 
    a.airline AS Airline, 
    a.seat_rows AS SeatRows, 
    a.seat_columns AS SeatColumns, 
    fr.flight_route_id AS FlightRouteId
FROM Flight f
INNER JOIN Airplane a ON f.airplane_id_FK = a.airplane_id
INNER JOIN Flight_Route fr ON f.flight_route_id_FK = fr.flight_route_id;
GO;