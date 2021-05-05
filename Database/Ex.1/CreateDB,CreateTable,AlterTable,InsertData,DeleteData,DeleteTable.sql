CREATE DATABASE Minions
-- To work with created database first we need to select it!

USE Minions
CREATE TABLE Towns
(
	Id int NOT NULL,
	NAME NVARCHAR(50) NOT NULL,

	PRIMARY KEY (Id)

)

CREATE TABLE Minions
(
	Id INT NOT NULL,
	[NAME] NVARCHAR(50) NOT NULL,
	AGE TINYINT

	PRIMARY KEY(Id)
)
-- Chek if we create properly tables

SELECT * FROM Towns
SELECT * FROM Minions

-- Add new column to Minions with references to Towns table

ALTER TABLE Minions
	 ADD TownID INT FOREIGN KEY REFERENCES Towns(Id)

-- Chek table Minions

SELECT * FROM Minions

-- If is nessery to alter some column after initial creation

ALTER TABLE MINIONS
	ALTER COLUMN AGE INT

-- Add to data to tables

INSERT INTO Towns(Id,[NAME])
	VALUES(1,'Sofia'),
		  (2,'Plovdiv'),
		  (3,'Varna')
INSERT INTO Minions (ID,[NAME],AGE,TownID)
	VALUES	(1,'Kevin',22,1),
			(2,'Bob',15,3),
			(3,'Steward',NULL,2)
-- Empty table Minions

TRUNCATE TABLE Minions

-- Delete tables, first Minions (with references) then Towns

DROP TABLE Minions
DROP TABLE Towns

--Delete database Minions,but first we have to selec different database for use

USE master
DROP DATABASE Minions