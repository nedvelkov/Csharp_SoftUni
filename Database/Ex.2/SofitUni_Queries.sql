USE SoftUni

-- Problem.2
SELECT * FROM Departments

-- Problem.3
SELECT [NAME] FROM Departments

-- Problem.4
SELECT FirstName,LastName,Salary FROM Employees

-- Proble.5
SELECT FirstName,MiddleName,LastName FROM Employees

-- Problem.6
SELECT FirstName+'.'+LastName+'@softuni.bg' AS [Full Email Address]
	FROM Employees

-- Problem.7
SELECT DISTINCT Salary FROM Employees

-- Problem.8
SELECT * FROM Employees
	WHERE JobTitle='Sales Representative'

-- Problem.9
SELECT FirstName,LastName,JobTitle FROM Employees
	WHERE Salary BETWEEN 20000 AND 30000
		ORDER BY Salary DESC

-- Problem.10
SELECT FirstName+' '+MiddleName+' '+LastName AS [Full Name] FROM Employees
	WHERE Salary=25000 OR Salary=14000 OR Salary = 12500 OR Salary=23600

-- Problem.11
SELECT FirstName,LastName FROM Employees
	WHERE ManagerID IS NULL

-- Problem.12
SELECT FirstName,LastName,Salary FROM Employees
	WHERE Salary>50000
	ORDER BY Salary DESC

-- Problem.13
SELECT TOP(5) FirstName,LastName FROM Employees
	ORDER BY Salary DESC

-- Problem.14
SELECT FirstName,LastName FROM Employees
	WHERE DepartmentID != 4

-- Problem15.
SELECT * FROM Employees
	ORDER BY Salary DESC,FirstName,LastName DESC,MiddleName

-- Problem.16
CREATE VIEW V_EmployeesSalaries AS
	SELECT FirstName,LastName,Salary FROM Employees

-- Problem.17
CREATE VIEW V_EmployeeNameJobTitle AS
	SELECT (FirstName+' '+MiddleName+' '+LastName) AS [Full Name],JobTitle FROM Employees

-- Problem.18
SELECT DISTINCT JobTitle FROM Employees

-- Problem.19
SELECT TOP(10) ProjectID,[Name],[Description],StartDate,EndDate FROM Projects
	ORDER BY StartDate

-- Problem.20
SELECT TOP(7) FirstName,LastName,HireDate FROM Employees
	ORDER BY HireDate DESC

-- Problem.21 ??
UPDATE Employees
	SET Salary=Salary*1.2
	WHERE DepartmentID=(SELECT DepartmentID FROM Departments WHERE Name='Engineering')
	OR DepartmentID=(SELECT DepartmentID FROM Departments WHERE Name='Tool Design')
	OR DepartmentID=(SELECT DepartmentID FROM Departments WHERE Name='Marketing')
	OR DepartmentID=(SELECT DepartmentID FROM Departments WHERE Name='Information Services')
SELECT Salary FROM Employees
	WHERE DepartmentID=(SELECT DepartmentID FROM Departments WHERE Name='Engineering')
	OR DepartmentID=(SELECT DepartmentID FROM Departments WHERE Name='Tool Design')
	OR DepartmentID=(SELECT DepartmentID FROM Departments WHERE Name='Marketing')
	OR DepartmentID=(SELECT DepartmentID FROM Departments WHERE Name='Information Services')

