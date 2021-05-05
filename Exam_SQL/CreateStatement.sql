CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users
(
	Id INT IDENTITY NOT NULL,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(30) NOT NULL,
	CONSTRAINT PK_Users PRIMARY KEY (Id)
)

CREATE TABLE Repositories
(
	Id INT IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Repositories PRIMARY KEY (Id)
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT NOT NULL,
	ContributorId INT NOT NULL,

	CONSTRAINT PK_RepositoriesContributors PRIMARY KEY(RepositoryId,ContributorId),

	CONSTRAINT FK_RepositoryId_Repository FOREIGN KEY (RepositoryId)
    REFERENCES Repositories(Id),

	CONSTRAINT FK_ContributorId_Users FOREIGN KEY (ContributorId)
    REFERENCES Users(Id)
)

CREATE TABLE Issues
(
	Id INT IDENTITY NOT NULL,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT NOT NULL,
	AssigneeId INT NOT NULL,

	CONSTRAINT PK_Issues PRIMARY KEY(Id),

	CONSTRAINT FK_Issues_Repository FOREIGN KEY (RepositoryId)
    REFERENCES Repositories(Id),

	CONSTRAINT FK_Issues_Users FOREIGN KEY (AssigneeId)
    REFERENCES Users(Id)
)

CREATE TABLE Commits
(
	Id INT IDENTITY NOT NULL,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT ,
	RepositoryId INT NOT NULL,
	ContributorId INT NOT NULL,

	CONSTRAINT PK_Commits PRIMARY KEY(Id),

	CONSTRAINT FK_Commits_Issues FOREIGN KEY (IssueId)
    REFERENCES Issues(Id),

	CONSTRAINT FK_Commits_Repository FOREIGN KEY (RepositoryId)
    REFERENCES Repositories(Id),

	CONSTRAINT FK_Commits_Users FOREIGN KEY (ContributorId)
    REFERENCES Users(Id)
)

CREATE TABLE Files
(
	Id INT IDENTITY NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL (22,2) NOT NULL,
	ParentId INT,
	CommitId INT NOT NULL,

	CONSTRAINT PK_Files PRIMARY KEY(Id),

	CONSTRAINT FK_ParentId_Files FOREIGN KEY (ParentId)
    REFERENCES Files(Id),

	CONSTRAINT FK_Files_Commits FOREIGN KEY (CommitId)
    REFERENCES Commits(Id),

)