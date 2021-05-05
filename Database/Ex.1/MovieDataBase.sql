CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

--   PersonID int FOREIGN KEY REFERENCES Persons(PersonID)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title NVARCHAR(250) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATE NOT NULL,
	[Length] TIME NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName)
	VALUES
		('J.J. Abrams'),
		('Steven Spielberg'),
		('Peter Jackson'),
		('Andrew Niccol'),
		('Quentin Tarantino')
INSERT INTO Genres(GenreName)
	VALUES
		('Thriller'),
		('Sci-Fi'),
		('Action'),
		('Fantasy'),
		('Drama')
INSERT INTO Categories(CategoryName)
	VALUES
		('USA'),
		('Europe'),
		('Russia'),
		('Chinise'),
		('India')

DROP TABLE Movies

INSERT INTO Movies(Title,DirectorId,CopyrightYear,[Length],GenreId,CategoryId)
	VALUES
		('Titanik',2,'1999','02:10:00',5,1),
		('Avatar',2,'2007','02:30:00',5,2),
		('Kill Bill',5,'2007','01:51:00',5,2),
		('The Lord of the Rings: The Two Towers',5,'2002','02:59:00',4,1),
		('Pirates of the Caribbean: The Curse of the Black Pearl',5,'2003','02:05:00',4,1)


SELECT * FROM Movies
