
USE UCNAirlines;
INSERT INTO Country VALUES ('Denmark');
INSERT INTO Country VALUES ('Greenland');

INSERT INTO City_Zip_Code VALUES ('9000', 'Aalborg', 1);
INSERT INTO City_Zip_Code VALUES ('7190', 'Billund', 1);

INSERT INTO City_Zip_Code VALUES ('3900', 'Nuuk', 2);
INSERT INTO City_Zip_Code VALUES ('3952', 'Ilulissat', 2);
INSERT INTO City_Zip_Code VALUES ('3910', 'Kangerlussuaq', 2);

INSERT INTO Airplane VALUES ('UCN1', 'UCN', 2, 2);
INSERT INTO Airplane VALUES ('UCN2', 'UCN', 2, 2);
INSERT INTO Airplane VALUES ('UCN3', 'UCN', 2, 2);
INSERT INTO Airplane VALUES ('UCN4', 'UCN', 2, 2);

INSERT INTO Airport VALUES ('EKYT', 'Aalborg Airport', '9000');
INSERT INTO Airport VALUES ('EKBI', 'Billund Airport', '7190');
INSERT INTO Airport VALUES ('BGGH', 'Nuuk Airport', '3900');
INSERT INTO Airport VALUES ('BGJN', 'Ilulissat Airport', '3952');
INSERT INTO Airport VALUES ('BGSF', 'Kangerlussuaq Airport', '3910');

INSERT INTO Flight_Route VALUES ('EKYT', 'BGGH');
INSERT INTO Flight_Route VALUES ('BGGH', 'EKYT');
INSERT INTO Flight_Route VALUES ('BGJN', 'EKYT');
INSERT INTO Flight_Route VALUES ('BGSF', 'EKBI');

INSERT INTO Flight VALUES ('01/06/2025 12:00', 'UCN1', 1);

INSERT INTO Booking VALUES (1);

INSERT INTO Passenger VALUES ('12345678', 'John', 'Johnsen', '01/01/1990');
INSERT INTO Passenger VALUES ('87654321', 'Hans', 'Hansen', '12/12/1950');

INSERT INTO Seat VALUES ('1A', '12345678', 1);
INSERT INTO Seat VALUES ('1B', '87654321', 1);
INSERT INTO Seat VALUES ('2A', null, 1);
INSERT INTO SEAT VALUES ('2B', null, 1);

INSERT INTO PassengerBooking VALUES (1, '12345678');
INSERT INTO PassengerBooking VALUES (1, '87654321');
