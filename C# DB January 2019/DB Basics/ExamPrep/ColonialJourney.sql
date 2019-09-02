CREATE DATABASE ColonialJourney
GO

USE ColonialJourney

--Task 1
CREATE TABLE Planets
	(
		Id		INT PRIMARY KEY IDENTITY,
		[Name]	VARCHAR(30) NOT NULL
	);

CREATE TABLE Spaceports
	(
		Id			INT PRIMARY KEY IDENTITY,
		[Name]		VARCHAR(50) NOT NULL,
		PlanetId	INT FOREIGN KEY(PlanetId) REFERENCES Planets(Id) NOT NULL
	);

CREATE TABLE Spaceships
	(
		Id				INT PRIMARY KEY IDENTITY,
		[Name]			VARCHAR(50) NOT NULL,
		Manufacturer	VARCHAR(30) NOT NULL,
		LightSpeedRate	INT DEFAULT 0
	);

CREATE TABLE Colonists
	(
		Id			INT PRIMARY KEY IDENTITY,
		FirstName	VARCHAR(20) NOT NULL,
		LastName	VARCHAR(20) NOT NULL,
		Ucn			VARCHAR(10) UNIQUE NOT NULL,
		BirthDate	DATE NOT NULL
	);

CREATE TABLE Journeys
	(
		Id						INT PRIMARY KEY IDENTITY,
		JourneyStart			DATETIME NOT NULL,
		JourneyEnd				DATETIME NOT NULL,
		Purpose					VARCHAR(11),
		DestinationSpaceportId	INT FOREIGN KEY(DestinationSpaceportId) REFERENCES Spaceports(Id) NOT NULL,
		SpaceshipId				INT FOREIGN KEY(SpaceshipId) REFERENCES Spaceships(Id) NOT NULL,
		CONSTRAINT CK_Purose CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military'))
	);

CREATE TABLE TravelCards
	(
		Id					INT PRIMARY KEY IDENTITY,
		CardNumber			CHAR(10) UNIQUE NOT NULL,
		JobDuringJourney	VARCHAR(10),
		ColonistId			INT FOREIGN KEY(ColonistId) REFERENCES Colonists(Id) NOT NULL,
		JourneyId			INT FOREIGN KEY(JourneyId) REFERENCES Journeys(Id) NOT NULL,
		CONSTRAINT CK_Job_During_Journey CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook'))
	);

BACKUP DATABASE ColonialJourney TO DISK = 'D:\Colonial_Journey.bak';
--Task 2
INSERT INTO Planets([Name]) VALUES
		(
			'Mars'
		), 
		
		(
			'Earth'
		), 
		
		(
			'Jupiter'
		), 
		
		(	
			'Saturn'
		);

INSERT INTO Spaceships([Name], Manufacturer, LightSpeedRate) VALUES
		(
			'Golf',	
			'VW',	
			3
		),

		(
			'WakaWaka',	
			'Wakanda',	
			4
		),

		(
			'Falcon9',	
			'SpaceX',	
			1
		),

		(
			'Bed',	
			'Vidolov',	
			6
		);

--Task 3
UPDATE Spaceships
	SET LightSpeedRate += 1
		WHERE Id BETWEEN 8 AND 12

--Task 4
ALTER TABLE TravelCards
ALTER COLUMN JourneyId INT

UPDATE TravelCards
SET JourneyId = NULL
	WHERE JourneyId IN (1,2,3)

DELETE TOP(3) FROM Journeys 
DELETE FROM TravelCards WHERE JourneyId IS NULL

USE master
DROP DATABASE ColonialJourney

RESTORE DATABASE ColonialJourney FROM DISK = 'D:\Colonial_Journey.bak';
GO
USE ColonialJourney

--Task 5
SELECT CardNumber, JobDuringJourney
	FROM TravelCards
ORDER BY CardNumber, JobDuringJourney

--Task 6
SELECT c.Id, c.FirstName + ' ' + c.LastName AS FullName, c.Ucn
	FROM Colonists AS c
ORDER BY c.FirstName, c.LastName, c.Id

--Task 7
SELECT j.Id, CONVERT(VARCHAR,j.JourneyStart,103), CONVERT(VARCHAR,j.JourneyEnd,103)
	FROM Journeys AS j
		WHERE j.Purpose LIKE 'Military'
ORDER BY j.JourneyStart

--Task 8
SELECT c.Id, c.FirstName + ' ' + c.LastName AS Fullname
	FROM Colonists AS c
		JOIN TravelCards AS tc ON tc.ColonistId = c.Id
	WHERE tc.JobDuringJourney LIKE 'Pilot'
ORDER BY c.Id

--Task 9
SELECT COUNT(j.Purpose)
	FROM Colonists AS c
		JOIN TravelCards AS tc ON tc.ColonistId = c.Id
		JOIN Journeys AS j ON tc.JourneyId = j.Id
		WHERE j.Purpose = 'Technical'

--Task 10
SELECT TOP(1) a.ShipName, a.PortName
	FROM 
		(
		SELECT 
				ship.[Name] AS ShipName, 
				port.[Name] AS PortName, 
				ship.LightSpeedRate AS Speed
			FROM Journeys AS j 
				JOIN Spaceships AS ship ON j.SpaceshipId = ship.Id
				JOIN Spaceports AS port ON j.DestinationSpaceportId = port.Id
		) AS a
ORDER BY a.Speed DESC
--Task 11
SELECT ship.[Name], ship.Manufacturer
	FROM TravelCards AS tc
		JOIN Journeys AS j ON tc.JourneyId = j.Id
		JOIN Spaceships AS ship ON j.SpaceshipId = ship.Id
		JOIN Colonists AS c ON tc.ColonistId = c.Id AND tc.JobDuringJourney = 'Pilot'
		WHERE DATEDIFF(YEAR,c.BirthDate,CAST('01/01/2019' AS DATETIME)) < 30
	GROUP BY ship.[Name], ship.Manufacturer
ORDER BY ship.[Name] 

--Task 12
SELECT p.[Name], port.[Name]
	FROM Journeys AS j
		JOIN Spaceports AS port ON j.DestinationSpaceportId = port.Id
		JOIN Planets AS p ON port.PlanetId = p.Id
		WHERE j.Purpose = 'Educational'
ORDER BY port.[Name] DESC

 --Task 13
 SELECT p.[Name], COUNT(j.Id) AS JourneysCount
	FROM Journeys AS j 
		JOIN Spaceports AS port ON j.DestinationSpaceportId = port.Id
		JOIN Planets AS p ON port.PlanetId = p.Id
	GROUP BY p.[Name]
ORDER BY JourneysCount DESC, p.[Name]

--Task 14
SELECT TOP(1)
		j.Id,
		j.PlanetName,
		j.SpacePortName,
		j.JourneyPurpose
	FROM(
			SELECT 
					j.Id AS Id,
					p.[Name] AS PlanetName,
					port.[Name] AS SpacePortName,
					j.Purpose AS JourneyPurpose,
					DATEDIFF(DAY,j.JourneyStart, j.JourneyEnd) AS [Range]
				FROM Journeys AS j
					JOIN Spaceports AS port ON j.DestinationSpaceportId = port.Id
					JOIN Planets AS p ON port.PlanetId = p.Id
				GROUP BY j.Id, p.[Name], port.[Name], j.Purpose, DATEDIFF(DAY,j.JourneyStart, j.JourneyEnd)
		) AS j
ORDER BY [Range] 

--Task 15
SELECT TOP(1) k.Id, k.JobName
	FROM
		(
		SELECT 
				j.Id AS Id,
				tc.JobDuringJourney AS JobName,
				DATEDIFF(HOUR,j.JourneyStart, j.JourneyEnd) AS TimeFrame,
				COUNT(tc.JobDuringJourney) AS [Count],
				DENSE_RANK() OVER (PARTITION BY j.Id,MAX(DATEDIFF(HOUR,j.JourneyStart, j.JourneyEnd))
				ORDER BY j.Id, COUNT(tc.JobDuringJourney)) AS [Rank]
			FROM Journeys AS j
				JOIN TravelCards AS tc ON tc.JourneyId = j.Id
			GROUP BY j.Id, tc.JobDuringJourney, DATEDIFF(HOUR,j.JourneyStart, j.JourneyEnd)
		) AS k
		WHERE k.[Rank] = 1
ORDER BY k.TimeFrame DESC
--Task 16
SELECT
		k.JobDuringJourney,
		k.FullName,
		k.JobRank
	FROM
			(
				SELECT 
						tc.JobDuringJourney AS JobDuringJourney,
						c.FirstName + ' ' + c.LastName AS FullName,
						DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney
						ORDER BY c.BirthDate) AS JobRank
					FROM TravelCards AS tc
						JOIN Colonists AS c ON tc.ColonistId = c.Id
						JOIN Journeys AS j ON tc.JourneyId = j.Id
			) AS k
		WHERE k.JobRank = 2

--Task 17
SELECT p.[Name], COUNT(port.Id) AS [Count]
	FROM Planets AS p
		LEFT JOIN Spaceports AS port ON port.PlanetId = p.Id
	GROUP BY p.[Name]
ORDER BY [Count] DESC, p.[Name]

--Task 18
CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
BEGIN
	DECLARE @Value TABLE ([Count] INT)

	INSERT INTO @Value  
			SELECT COUNT(c.Id) AS [Count]
				FROM Colonists AS c
					JOIN TravelCards AS tc ON tc.ColonistId = c.Id
					JOIN Journeys AS j ON tc.JourneyId = j.Id
					JOIN Spaceports AS port ON j.DestinationSpaceportId = port.id
					JOIN Planets AS p ON port.PlanetId = p.Id
					WHERE p.[Name] = @PlanetName

	DECLARE @result INT = (SELECT Count FROM @Value)
	RETURN @result
END

--Task 19
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
	DECLARE @Journey INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId)

	IF(@Journey IS NULL)
	BEGIN
		RAISERROR ('The journey does not exist!', 16,1)
		RETURN
	END

	DECLARE @purpose VARCHAR(11) = (SELECT Purpose FROM Journeys WHERE Purpose = @NewPurpose AND Id = @JourneyId)

	IF (@purpose = @NewPurpose)
	BEGIN
		RAISERROR ('You cannot change the purpose!', 16,1)
		RETURN
	END

	UPDATE Journeys
	SET Purpose = @NewPurpose WHERE Id = @JourneyId

--Task 20
CREATE TABLE DeletedJourneys
	(
		Id INT, 
		JourneyStart DATETIME, 
		JourneyEnd DATETIME, 
		Purpose VARCHAR(11), 
		DestinationSpaceportId INT, 
		SpaceshipId INT
	);

CREATE TRIGGER tr_Trigger_On_Delete ON Journeys FOR DELETE
AS
	INSERT INTO DeletedJourneys(Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId)
		SELECT Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId FROM deleted
