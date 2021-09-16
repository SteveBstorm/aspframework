CREATE TABLE Film(
	Id INT IDENTITY,
	Titre VARCHAR(100) NOT NULL,
	Description VARCHAR(250),
	Annee INT NOT NULL,

	CONSTRAINT PK_Film PRIMARY KEY(Id)
)

INSERT INTO Film (Titre, Description, Annee) VALUES('Star Wars', 'Chewbacca et ses amis détruisent Leia sauvagement !', 1977)

CREATE TABLE Users(
	Id INT IDENTITY,
	Login VARCHAR(60) NOT NULL,
	Pwd VARCHAR(60) NOT NULL,
	IsAdmin BIT NOT NULL DEFAULT(0),
	IsActive Bit NOT NULL DEFAULT(1),

	CONSTRAINT PK_Users PRIMARY KEY(Id)
)


INSERT INTO Users (Login, Pwd, IsAdmin) VALUES ('steve', 'test', 1)