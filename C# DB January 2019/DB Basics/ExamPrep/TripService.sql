CREATE DATABASE TripService
GO

USE TripService

--Task 1
CREATE TABLE Cities
	(
		Id			INT PRIMARY KEY IDENTITY,
		[Name]		NVARCHAR(20) NOT NULL,
		CountryCode VARCHAR(2) NOT NULL
	);
	
CREATE TABLE Hotels
	(
		Id				INT PRIMARY KEY Identity,
		[Name]			NVARCHAR(30) NOT NULL ,
		CityId			INT FOREIGN KEY(CityId) REFERENCES Cities(Id) NOT NULL,
		EmployeeCount	INT NOT NULL,
		BaseRate		DECIMAL(15,2)
	);

CREATE TABLE Rooms
	(
		Id		INT PRIMARY KEY IDENTITY,
		Price	DECIMAL(15,2) NOT NULL,
		[Type]	NVARCHAR(20) NOT NULL,
		Beds	INT NOT NULL,
		HotelId	INT FOREIGN KEY(HotelId) REFERENCES Hotels(Id)	NOT NULL
	);

CREATE TABLE Trips
	(
		Id			INT PRIMARY KEY Identity,
		RoomId		INT FOREIGN KEY(RoomId) REFERENCES Rooms(Id) NOT NULL,
		BookDate	Date NOT NULL ,
		ArrivalDate	Date NOT NULL ,
		ReturnDate	Date NOT NULL,
		CancelDate	Date,
		CONSTRAINT CK_Book_Date CHECK(BookDate < ArrivalDate),
		CONSTRAINT CK_Arrival_Date CHECK (ArrivalDate < ReturnDate)
	);

CREATE TABLE Accounts
	(
		Id			INT PRIMARY KEY Identity,
		FirstName	NVARCHAR(50) NOT NULL,
		MiddleName	NVARCHAR(20),	
		LastName	NVARCHAR(50) NOT NULL,
		CityId		INT FOREIGN KEY(CityId) REFERENCES Cities(Id) NOT NULL,
		BirthDate	Date	NOT NULL,
		Email		VARCHAR(100) UNIQUE NOT NULL
	);

CREATE TABLE AccountsTrips
	(
		AccountId	INT FOREIGN KEY(AccountId) REFERENCES Accounts(Id),
		TripId		INT FOREIGN KEY(TripId) REFERENCES Trips(Id),
		Luggage		INT NOT NULL,
		PRIMARY KEY(AccountId,TripId),
		CONSTRAINT CK_Luggage CHECK (Luggage >= 0)
	);

--Task 2
INSERT INTO Accounts
	(
		FirstName,
		MiddleName,
		LastName,
		CityId,
		BirthDate,
		Email
	) 
		VALUES
			(	
				'John',
				'Smith',
				'Smith',
				34,
				'1975-07-21',
				'j_smith@gmail.com'
			),
	
			(
				'Gosho',
				NULL,
				'Petrov',
				11,
				'1978-05-16',
				'g_petrov@gmail.com'
			),

			(
				'Ivan',
				'Petrovich',
				'Pavlov',
				59,
				'1849-09-26',
				'i_pavlov@softuni.bg'
			),
			
			(
				'Friedrich',
				'Wilhelm',
				'Nietzsche',
				2,
				'1844-10-15',
				'f_nietzsche@softuni.bg'
			);

INSERT INTO Trips 
	(
		RoomId,
		BookDate,
		ArrivalDate,
		ReturnDate,
		CancelDate
	) 
		VALUES
			(
				101,
				'2015-04-12',
				'2015-04-14',
				'2015-04-20',
				'2015-02-02'
			),

			(	
				102,
				'2015-07-07',
				'2015-07-15',
				'2015-07-22',
				'2015-04-29'
			),

			(
				103,
				'2013-07-17',
				'2013-07-23',
				'2013-07-24',
				NULL
			),

			(
				104,
				'2012-03-17',
				'2012-03-31',
				'2012-04-01',
				'2012-01-10'
			),

			(
				109,
				'2017-08-07',
				'2017-08-28',
				'2017-08-29',
				NULL
			);


--Task 3
BACKUP DATABASE TripService TO DISK = 'D:\Trip_Service_Before_Raise.bak';

UPDATE Rooms
	SET Price *= 1.14
		WHERE HotelId IN (5,7,9);

--Task 4
BACKUP DATABASE TripService TO DISK = 'D:\Trip_Service_Before_Delete.bak';

DELETE FROM AccountsTrips
		WHERE AccountId = 47

--Task 5
SELECT Id,[Name]
	FROM Cities AS c
		WHERE c.CountryCode = 'BG'
ORDER BY [Name];

--Task 6
SELECT 
		CONCAT(
				FirstName, 
				CASE 
					WHEN MiddleName IS NULL
						THEN ' '
					ELSE ' ' + MiddleName + ' '
				END,
				LastName) AS [Full Name],
		YEAR(BirthDate) AS [Birth Year]
	FROM Accounts
		WHERE YEAR(BirthDate) > 1991
ORDER BY 
		[Birth Year] DESC,
		FirstName

--Task 7
SELECT 
		a.FirstName,
		a.LastName,
		FORMAT(a.BirthDate,'MM-dd-yyyy') AS [BirthDate],
		c.[Name] AS Hometown,
		a.Email
	FROM Accounts AS a
		JOIN Cities AS c ON c.Id = a.CityId
		WHERE a.Email LIKE 'e%'
ORDER BY Hometown DESC

--Task 8
SELECT 
		c.[Name] AS [City],
		COUNT(h.Id) AS [Hotels]
	FROM Cities AS c
		LEFT JOIN Hotels AS h ON h.CityId = c.Id 
	GROUP BY c.[Name]
ORDER BY 
		 [Hotels] DESC,
		 [City]

--Task 9
SELECT 
		r.Id,
		r.Price,
		h.[Name] AS Hotel,
		c.[Name] AS City
	FROM Rooms AS r
		JOIN Hotels AS h ON r.HotelId = h.Id
		JOIN Cities AS c ON h.CityId = c.Id
	WHERE r.[Type] = 'First Class'
ORDER BY r.Price DESC, r.Id

--Task 10
SELECT 
		a.Id AS AccountId,
		(a.FirstName + ' ' + a.LastName) AS FullName,
		MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip,
		MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
	FROM Accounts AS a
		JOIN AccountsTrips AS acct ON a.Id = acct.AccountId
		JOIN Trips AS t ON acct.TripId = t.Id 
	WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
	GROUP BY a.Id, (a.FirstName + ' ' + a.LastName)
ORDER BY LongestTrip DESC, AccountId

--Task 11
SELECT TOP(5) 
				c.Id, 
				c.[Name] AS City, 
				c.CountryCode,
				COUNT(a.Id) AS Accounts
	FROM Cities AS c
		JOIN Accounts AS a ON c.Id = a.CityId
	GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY Accounts DESC

--Task 12
SELECT 
		a.Id,
		a.Email,
		c.[Name],
		COUNT(*) AS Trips
	FROM Accounts AS a
		JOIN AccountsTrips AS acct ON a.Id = acct.AccountId
		JOIN Trips AS t ON acct.TripId = t.Id
		JOIN Rooms AS r ON r.Id = t.RoomId
		JOIN Hotels AS h ON r.HotelId = h.Id
		JOIN Cities AS c ON h.CityId = c.Id
		WHERE a.CityId = h.CityId
	GROUP BY a.Id, a.Email, c.[Name]
ORDER BY Trips DESC, a.Id

--Task 13
SELECT TOP(10) 
				c.Id, 
				c.[Name],
				SUM(h.BaseRate + r.Price) AS [Total Revenue],
				COUNT(*) AS Trips
	FROM Cities AS c
		JOIN Hotels AS h ON h.CityId = c.Id
		JOIN Rooms AS r ON r.HotelId = h.Id
		JOIN Trips AS t ON t.RoomId =r.Id
		WHERE YEAR(t.BookDate) = 2016
	GROUP BY c.Id, c.[Name]
ORDER BY [Total Revenue] DESC, Trips DESC

--Task 14
SELECT 
		t.Id AS Id, 
		h.[Name] AS HotelName, 
		r.[Type] AS RoomType,
		(
			CASE 
				WHEN t.CancelDate IS NULL
					THEN SUM(h.BaseRate + r.Price)
				ELSE 0
			END
		) AS Revenue
	FROM Trips AS t
		JOIN Rooms AS r ON t.RoomId = r.Id
		JOIN Hotels AS h ON r.HotelId = h.Id
		JOIN AccountsTrips AS at ON at.TripId = t.Id
	GROUP BY t.Id,h.[Name], r.[Type], t.CancelDate
ORDER BY RoomType, Id
		
--Task 15
SELECT 
		AccountId,
		Email,
		CountryCode,
		Trips
	FROM 
	(
		SELECT 
				a.Id			AS AccountId,
				a.Email,
				c.CountryCode,
				COUNT(*)		AS Trips,
				DENSE_RANK() 
				OVER(PARTITION BY c.CountryCode 
				ORDER BY COUNT(*) DESC, a.Id) AS Rank
			FROM Accounts AS a
				JOIN AccountsTrips AS act ON act.AccountId = a.Id
				JOIN Trips AS t ON act.TripId = t.Id
				JOIN Rooms AS r ON t.RoomId = r.Id
				JOIN Hotels AS h ON r.HotelId = h.Id
				JOIN Cities AS c ON h.CityId = c.Id
			GROUP BY c.CountryCode, a.Email, a.Id
			) AS s 
		WHERE Rank = 1
ORDER BY Trips DESC, AccountId

--Task 16
SELECT 
		act.TripId, 
		SUM(act.Luggage) AS Luggage, 
		CONCAT('$', CONVERT (VARCHAR(10), 
		CASE
			WHEN SUM(act.Luggage) > 5
				THEN SUM(act.Luggage) * 5	
			ELSE 0
		END)) AS Fee 
	FROM AccountsTrips AS act
	GROUP BY act.TripId
		HAVING SUM(act.Luggage) > 0
ORDER BY Luggage DESC

--Task 17
SELECT  
		t.Id AS TripId,
		CONCAT(a.FirstName, ' ' + a.MiddleName, ' ',a.LastName) As [Full Name],
		homeC.[Name] AS [From],
		travelC.[Name] AS [To],
		(CASE
			WHEN t.CancelDate IS NULL
				THEN CONVERT(VARCHAR(10),DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) + ' days'
			ELSE 'Canceled'
		END) AS Duration
	FROM Trips AS t
		JOIN AccountsTrips AS act ON act.TripId = t.Id
		JOIN Accounts AS a ON act.AccountId = a.Id
		JOIN Rooms AS r ON t.RoomId = r.Id
		JOIN Hotels AS h ON r.HotelId = h.Id
		JOIN Cities AS homeC ON a.CityId = homeC.Id
		JOIN Cities AS travelC ON h.CityId = travelC.Id	
ORDER BY [Full Name], TripId

--Task 18
