
--use ContactDB;
--GO
--CREATE TABLE personne (
--	id INT IDENTITY(1,1) PRIMARY KEY,
--	prenom NVARCHAR(50) NOT NULL,
--	nom NVARCHAR(50) NOT NULL,
--	email VARCHAR(255) NOT NULL
--);
--GO

--INSERT INTO
--	personne
--	(prenom, nom, email)
--VALUES
--	('Jean', 'Michel', 'jean@michel.fr');
--GO

CREATE TABLE Student (
	id INT IDENTITY(1,1) PRIMARY KEY,
	firstName NVARCHAR(50) NOT NULL,
	lastName NVARCHAR(50) NOT NULL,
	classNumber INT NOT NULL,
	licenseDate DATE,
);
GO

DROP TABLE Student;