CREATE DATABASE HotelDatabase

USE HotelDatabase

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)


CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(10) NOT NULL, 
		--CHECK (LEN(PhoneNumber)=10),
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus
(
	RoomStatus bit PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus
	VALUES
		(0),
		(1)

CREATE TABLE RoomTypes
(
	RoomTypes NVARCHAR(10) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes
(
	BedTypes NVARCHAR(10) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

-- Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType NVARCHAR(10) NOT NULL,
	BedType NVARCHAR(10) NOT NULL,
	Rate INT NOT NULL,
	RoomStatus BIT FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NVARCHAR(MAX)
)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays DATETIMEOFFSET,
	AmountCharged DECIMAL(7,2) NOT NULL,
	TaxRate FLOAT(2) NOT NULL,
	TaxAmount DECIMAL(7,2),
	PaymentTotal DECIMAL(8,2),
	Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied INT NOT NULL,
	PhoneCharge DECIMAL (5,2) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies(EmployeeId,DateOccupied,AccountNumber,RoomNumber,RateApplied,PhoneCharge)
	VALUES
		(1,'5-10-2020',4574,2,10,75.20),
		(2,'8-25-2020',4845,1,5,75.20),
		(3,'7-03-2020',4698,3,7,75.20)


INSERT INTO Employees (FirstName,LastName)
	VALUES
		('Ivan','Velkov'),
		('Pesho','Ivanov'),
		('Ivan','Petrov')

INSERT INTO Rooms(RoomNumber,RoomType,BedType,Rate)
	VALUES
		(1,'Singe','Singe',7),
		(2,'Singe','Singe',8),
		(3,'Appartment','2-person',7)
INSERT INTO Payments(EmployeeId,PaymentDate,AccountNumber,
					FirstDateOccupied,LastDateOccupied,AmountCharged,TaxRate)
	VALUES
		(1,'5-10-2020',4584,'10-10-2020','10-25-2020',500.25,10.5),
		(2,'5-10-2020',8742,'7-05-2020','7-14-2020',350.25,10.5),
		(3,'5-10-2020',6941,'08-25-2020','9-12-2020',720.25,10.5)
