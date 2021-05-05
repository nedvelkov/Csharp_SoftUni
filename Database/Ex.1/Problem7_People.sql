CREATE DATABASE People

USE People

CREATE TABLE People
(
	[Id] INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	[Name] NCHAR(200) NOT NULL,
	[Picture] IMAGE ,
	[Height] FLOAT(2),
	[Weight] FLOAT(2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biography] VARCHAR(MAX)
)

INSERT INTO People
		--	NAME, PIC,HEIGHT,WEIGHT,GENDER,BIRTHDAY,BIOGRAPHY
	VALUES ('Ivan',NULL,1.85,82.51,'M','1994-03-14',NULL),
		   ('Pesho',NULL,1.65,95,'M','1992-05-21',NULL),
		   ('Ivona',NULL,1.65,60,'F','1990-01-07',NULL),
		   ('Eli',NULL,1.60,45,'F','1994-02-21',NULL),
		   ('Gosho',NULL,1.87,95.05,'M','1995-05-06',NULL)
	
SELECT * FROM People
USE master
DROP DATABASE People