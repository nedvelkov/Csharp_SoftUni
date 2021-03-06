CREATE DATABASE SoftUni

USE SOftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL

)

CREATE TABLE [Address]
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(50) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)
DROP TABLE Employees
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(30) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate Date NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	AddresId INT FOREIGN KEY REFERENCES [Address](Id)
)
INSERT INTO Towns
	VALUES
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas')

INSERT INTO Departments
	VALUES
		('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance')
SELECT * FROM Departments
		/*
		Georgi Teziev Ivanov	CEO	Sales	09/12/2007	3000.00
		Peter Pan Pan	Intern	Marketing	28/08/2016	599.88
		*/

INSERT INTO Employees(FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary)
	VALUES
		('Ivan','Ivanov','Ivanov','.NET Developer',4,'02/01/2013','3500.00'),
		('Petar','Petrov','Petrov','Senior Engineer',1,'03/02/2004','4000.00'),
		('Maria','Petrova','Ivanova','Intern',5,'08/28/2016','525.25'),
		('Georgi','Teziev','Ivanov','CEO',2,'12/09/2007','3000.00'),
		('Peter','Pan','Pan','Intern',3,'08/28/2016','599.88')
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

SELECT * FROM Towns
	ORDER BY [Name] ASC

SELECT * FROM Departments
	ORDER BY [Name] DESC

SELECT * FROM Employees
	ORDER BY [FirstName] ASC

SELECT [Name] FROM Towns
/*
FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(30) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate Date NOT NULL,
	Salary 
	*/
SELECT FirstName,LastName,JobTitle,Salary FROM Employees
	ORDER BY Salary DESC
	-- CHANGE VALUES IN TABLE -> UPDATE
	-- CHANGE TABLE -> ALTER
UPDATE Employees
	SET Salary+=Salary*0.1

SELECT SALARY FROM Employees

