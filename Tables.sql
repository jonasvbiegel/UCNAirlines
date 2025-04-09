DROP TABLE Flight, Flight_Route, Airport, Boarding_Pass, Seat, Airplane, Passenger, Booking, Customer, City_Zip_Code;

CREATE TABLE City_Zip_Code (
    zipcode VARCHAR(16) NOT NULL PRIMARY KEY,
    city VARCHAR(32) NOT NULL
);

CREATE TABLE Customer (
    customer_id INT NOT NULL PRIMARY KEY,
    first_name VARCHAR(64) NOT NULL,
    last_name VARCHAR(64) NOT NULL,
    birth_date DATE NOT NULL,
    email VARCHAR(256) NOT NULL,
    phoneNo VARCHAR(128) NOT NULL
);

CREATE TABLE Booking (
    booking_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id_FK int FOREIGN KEY REFERENCES Customer(customer_id)
);

CREATE TABLE Passenger (
    passport_no VARCHAR(128) NOT NULL PRIMARY KEY,
    first_name VARCHAR(64) NOT NULL,
    last_name VARCHAR(64) NOT NULL,
    birth_date DATE NOT NULL,
    baggage BIT NOT NULL
)

CREATE TABLE Airplane (
    airplane_id VARCHAR(128) NOT NULL PRIMARY KEY,
    model VARCHAR(128) NOT NULL,
    seat_rows INT NOT NULL,
    seat_columns INT NOT NULL
);

CREATE TABLE Seat (
    seat_id VARCHAR(128) NOT NULL PRIMARY KEY,
    is_booked BIT NOT NULL,
    airplane_id_FK VARCHAR(128) NOT NULL FOREIGN KEY REFERENCES Airplane(airplane_id)
);

CREATE TABLE Boarding_Pass (
    booking_id_FK INT FOREIGN KEY REFERENCES Booking(booking_id),
    passport_no_FK VARCHAR(128) FOREIGN KEY REFERENCES Passenger(passport_no),
    seat_id_FK VARCHAR(128) FOREIGN KEY REFERENCES Seat(seat_id),
    PRIMARY KEY (booking_id_FK, passport_no_FK)
);

CREATE TABLE Airport (
    airport_id VARCHAR(128) NOT NULL PRIMARY KEY,
    street VARCHAR(128) NOT NULL,
    streetNo VARCHAR(32) NOT NULL,
    country VARCHAR(64) NOT NULL,
    zipcode_FK VARCHAR(16) FOREIGN KEY REFERENCES City_Zip_Code(zipcode)
);

CREATE TABLE Flight_Route (
    flight_route_id INT IDENTITY(1,1) PRIMARY KEY,
    start_destination_FK VARCHAR(128) FOREIGN KEY REFERENCES Airport(airport_id),
    end_destination_FK VARCHAR(128) FOREIGN KEY REFERENCES Airport(airport_id),
    distance INT NOT NULL,
    CHECK (start_destination_FK <> end_destination_FK),
    UNIQUE(start_destination_FK, end_destination_FK)
);

CREATE TABLE Flight (
    airplane_id_FK VARCHAR(128) FOREIGN KEY REFERENCES Airplane(airplane_id),
    datetime DATETIME NOT NULL,
    seat_id_FK VARCHAR(128) FOREIGN KEY REFERENCES Seat(seat_id),
    flight_route_id_FK INT FOREIGN KEY REFERENCES Flight_Route(flight_route_id)
)
