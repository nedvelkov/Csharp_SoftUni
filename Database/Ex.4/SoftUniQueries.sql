
-- PROBLEM.1
SELECT FirstName,LastName FROM Employees
	WHERE FirstName LIKE 'SA%'
-- PROBLEM.2
SELECT FirstName,LastName FROM Employees
	WHERE LastName LIKE '%ei%'
-- PROBLEM.3
SELECT FirstName FROM Employees
	WHERE (DepartmentID=3 OR DepartmentID=10) 
		AND (HireDate > '1995-1-1' AND HireDate<'2005-12-31')
-- PROBLEM.4
SELECT FirstName,LastName FROM Employees
	WHERE NOT JobTitle LIKE '%engineer%'
-- PROBLEM.6
SELECT * FROM Towns
	WHERE [Name] LIKE 'M%' OR [Name] LIKE 'K%' OR [Name] LIKE 'B%' OR [Name] LIKE 'E%'
		ORDER BY [Name] ASC
-- PROBLEM.7

SELECT * FROM Towns
	WHERE (NOT [Name] LIKE 'R%') AND (NOT [Name] LIKE 'B%') AND (NOT [Name] LIKE 'D%' OR [Name] LIKE 'E%')
		ORDER BY [Name] ASC

-- PROBLEM.8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,LastName FROM Employees
	WHERE HireDate>'2000-12-31'

-- PROBLEM.9
SELECT FirstName,LastName FROM Employees
	 WHERE LEN(LastName)=5
	 /*
DENSE_RANK() OVER   
    (PARTITION BY i.LocationID ORDER BY i.Quantity DESC) AS Rank 
	 */
-- PROBLEM.10 Не работи в Judje
SELECT EmployeeID,FirstName,LastName,Salary,
	DENSE_RANK () OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
		FROM Employees
	WHERE Salary>10000  AND Salary<50000 
		ORDER BY Salary DESC
		
-- PROBLEM.11 Не работи в Judje
SELECT * FROM(
SELECT EmployeeID,FirstName,LastName,Salary,
	DENSE_RANK () OVER (PARTITION BY Salary ORDER BY EmployeeID) AS currentRank
		FROM Employees
	WHERE ( Salary>10000  AND Salary<50000)
		) AS T
		WHERE currentRank=2
		ORDER BY Salary DESC