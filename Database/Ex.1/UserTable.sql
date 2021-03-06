CREATE DATABASE USERS

USE USERS

CREATE TABLE Users
(
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL ,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX)
		
		CHECK (DATALENGTH(ProfilePicture)<=900*1024),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
)

INSERT INTO Users
	VALUES 
		('Pesho','asw12',NULL,'2008-11-11 11:12:01',0),
		('Ivan','a123S2',NULL,'2018-12-01 10:12:01',0),
		('Ivona','a2sw12',NULL,'2008-11-11 11:12:01',0),
		('Gosho','as231w12',NULL,'2008-11-11 11:12:01',0),
		('Ani','asw12312',NULL,'2008-11-11 11:12:01',0)


SELECT * FROM USERS

ALTER TABLE USERS
	DROP CONSTRAINT [PK__Users__3214EC07C98FADDF]
ALTER TABLE Users
	ADD CONSTRAINT PK_Users_Composed
		PRIMARY KEY(Id,UserName)
ALTER TABLE Users
	ADD CONSTRAINT CK_Users_PasswordLenght
		CHECK( LEN([Password]) >=5)

ALTER TABLE Users
	ADD CONSTRAINT DF_Users_LastLoginTime
		DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE USERS
	DROP CONSTRAINT PK_Users_Composed

ALTER TABLE USERS
		ADD CONSTRAINT PR_Users_ID
			PRIMARY KEY(Id)

ALTER TABLE USERS
		ADD CONSTRAINT CH_Users_Name
			CHECK( LEN([Username]) >=3)
