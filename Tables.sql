USE UCNAirlines

DROP TABLE IF EXISTS Passenger, Seat, Flight, Flight_Route, Airport, Airplane, Booking, Customer, City_Zip_Code, Country;

CREATE TABLE Country (
    country_id INT IDENTITY(1,1) PRIMARY KEY,
    country VARCHAR(128) NOT NULL
)

CREATE TABLE City_Zip_Code (
    zipcode VARCHAR(16) NOT NULL PRIMARY KEY,
    city VARCHAR(32) NOT NULL,
    country_id_FK INT FOREIGN KEY REFERENCES Country(country_id)
);

CREATE TABLE Customer (
    customer_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(64) NOT NULL,
    last_name VARCHAR(64) NOT NULL,
    birth_date DATE NOT NULL,
    email VARCHAR(256) NOT NULL,
    phoneNo VARCHAR(128) NOT NULL
);

CREATE TABLE Booking (
    booking_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id_FK INT FOREIGN KEY REFERENCES Customer(customer_id)
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
    UNIQUE(start_destination_FK, end_destination_FK)
);

CREATE TABLE Flight (
    flight_id INT IDENTITY(1,1) PRIMARY KEY,
    airplane_id_FK VARCHAR(128) FOREIGN KEY REFERENCES Airplane(airplane_id),
    datetime DATETIME NOT NULL,
    flight_route_id_FK INT FOREIGN KEY REFERENCES Flight_Route(flight_route_id)
)

CREATE TABLE Seat (
    seat_id INT IDENTITY(1,1) PRIMARY KEY,
    seat_name VARCHAR(128) NOT NULL,
    is_booked BIT NOT NULL,
    flight_id_FK INT NOT NULL FOREIGN KEY REFERENCES Flight(flight_id),
);

CREATE TABLE Passenger (
    passport_no VARCHAR(128) NOT NULL PRIMARY KEY,
    first_name VARCHAR(64) NOT NULL,
    last_name VARCHAR(64) NOT NULL,
    birth_date DATE NOT NULL,
    baggage BIT NOT NULL,
    booking_id_fk INT NOT NULL FOREIGN KEY REFERENCES Booking(booking_id),
    seat_id_FK INT NOT NULL FOREIGN KEY REFERENCES Seat(seat_id) UNIQUE
)





