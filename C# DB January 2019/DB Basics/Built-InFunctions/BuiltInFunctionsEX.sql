--Task 1
USE SoftUni

SELECT FirstName,LastName FROM Employees 
		WHERE [FirstName] LIKE 'SA%'

--Task 2
SELECT FirstName,LastName FROM Employees 
		WHERE [LastName] LIKE '%ei%'

--Task 3
SELECT FirstName FROM Employees
	WHERE 
		(DepartmentID = 3 OR DepartmentID = 10)
			AND
		(DATEPART(YEAR,HireDate) BETWEEN 1995 AND 2005)

--Task 4
SELECT FirstName,LastName FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

--Task 5
SELECT [Name] FROM Towns
	WHERE LEN([Name]) BETWEEN 5 AND 6
		ORDER BY [Name]

--Task 6
SELECT * FROM Towns
	WHERE [Name] LIKE 'M%' 
		OR [Name] LIKE 'K%'
		OR [Name] LIKE 'B%' 
		OR [Name] LIKE'E%'
			ORDER BY [Name]

--Task 7
SELECT * FROM Towns
	WHERE [Name] NOT LIKE 'R%' 
		AND [Name] NOT LIKE 'B%'
		AND [Name] NOT LIKE 'D%' 
			ORDER BY [Name]

--Task 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT FirstName,LastName FROM Employees
		WHERE DATEPART(YEAR,HireDate) > 2000

--Task 9
SELECT FirstName,LastName FROM Employees
	WHERE LEN(LastName) = 5

--Task 10
SELECT EmployeeID,FirstName,LastName,Salary,DENSE_RANK () OVER (PARTITION BY Salary ORDER BY EmployeeId) AS Rank
	 FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000
			ORDER BY Salary DESC

--Task 11
SELECT * FROM (
SELECT EmployeeID,FirstName,LastName,Salary, DENSE_RANK () OVER (PARTITION BY Salary ORDER BY EmployeeId) AS 'Rank'
	 FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000) AS RankTable
			WHERE Rank = 2
				ORDER BY Salary DESC

--Task 12
USE Geography
GO

SELECT CountryName AS 'Country Name',IsoCode AS 'ISO Code'
	FROM Countries
		WHERE CountryName LIKE '%a%a%a%'
			ORDER BY IsoCode

--Task 13
SELECT * FROM (
	SELECT PeakName AS PeakName,
			RiverName AS RiverName,
			LOWER(CONCAT(PeakName , RIGHT(RiverName, LEN(RiverName) - 1))) AS Mix
		FROM Peaks,Rivers) AS TempTable
	WHERE RIGHT(PeakName, 1) = LEFT(RiverName,1)
	ORDER BY Mix

--Task 14
USE Diablo
GO

SELECT TOP(50) [Name],FORMAT(CAST(Start AS DATE), 'yyyy-MM-dd') AS [Start]
	FROM Games
		WHERE DATEPART(YEAR,[Start]) = 2011 OR DATEPART(YEAR,[Start]) = 2012
	ORDER BY [Start],[Name]
	
--Task 15
SELECT Username, 
		RIGHT(Email, LEN(Email)-CHARINDEX('@', Email)) AS [Email Provider]
	FROM Users
		ORDER BY [Email Provider],Username

--Task 16
SELECT Username,IpAddress 
	FROM Users
		WHERE IpAddress LIKE '___.1_%._%.___'
	ORDER BY Username

--Task 17
SELECT [Name] AS [Game],
		CASE
			WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11
				THEN 'Morning'
			WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17
				THEN 'Afternoon'
			WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 24
					THEN 'Evening'
		END AS [Part of the Day],
		CASE 
			WHEN Duration <= 3
				THEN 'Extra Short'
			WHEN Duration >= 4 AND Duration <= 6
				THEN 'Short'
			WHEN Duration > 6
				THEN 'Long'
			ELSE 'Extra Long'
		END AS [Duration]
	FROM Games
		ORDER BY Game,[Duration],[Part of the Day]

--Task 18
SELECT ProductName,
       OrderDate,
       DATEADD(DAY, 3, OrderDate) AS [Pay Due],
       DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders;

--Task 19
CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
Birthdate DATETIME2 NOT NULL)

INSERT INTO People VALUES
('Victor','2000-12-07 00:00:00.000'),
('Steven','1992-09-10 00:00:00.000'),
('Stephen','1910-09-19 00:00:00.000'),
('John','2010-01-06 00:00:00.000');

SELECT Name,
       DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
       DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
       DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
       DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People;

DROP TABLE People;