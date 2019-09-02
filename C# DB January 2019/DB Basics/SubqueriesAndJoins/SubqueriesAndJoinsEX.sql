--Task 1
USE SoftUni

SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
	FROM Employees AS e
		JOIN Addresses AS a ON e.AddressID = a.AddressID
	ORDER BY a.AddressID 

--Task 2
SELECT TOP(50) e.FirstName, e.LastName,t.[Name], a.AddressText
	FROM Employees AS e
		JOIN Addresses AS a ON e.AddressID = a.AddressID
		JOIN Towns AS t ON a.TownID = t.TownID
	ORDER BY e.FirstName,
				e.LastName

--Task 3
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
	FROM Employees AS e
		JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'Sales'
	ORDER BY e.EmployeeID

--Task 4
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
	FROM Employees AS e
		JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY e.DepartmentID

--Task 5
SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM Employees AS e
		LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	WHERE ep.EmployeeID IS NULL
	ORDER BY e.EmployeeID

--Task 6
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName
	FROM Employees AS e
		JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '1.1.1999' AND (d.[Name] = 'Finance' OR d.[Name] = 'Sales')
	ORDER BY e.HireDate

--Task 7
SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS ProjectName
	FROM Employees AS e
		JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
		JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > CONVERT(SMALLDATETIME, '13.08.2002', 103) AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

--Task 8
SELECT e.EmployeeID,
	   e.FirstName, (
	   CASE
			WHEN YEAR(p.StartDate) >= '2005'
				THEN NULL
			ELSE  p.[Name]
		END
			) AS ProjectName
	FROM Employees AS e
		JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
		JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

--Task 9
SELECT e.EmployeeID, 
		e.FirstName,
		 e.ManagerID, 
			(SELECT FirstName 
				FROM Employees AS temp 
				WHERE e.ManagerID = temp.EmployeeID)
	FROM Employees AS e
	WHERE e.ManagerID IN (7,3)
	ORDER BY EmployeeID

--Task 10
SELECT TOP(50) e.EmployeeID,
				(e.FirstName + ' ' + e.LastName) AS EmployeeName,
				(SELECT (FirstName + ' ' + LastName) 
					FROM Employees
						WHERE e.ManagerID = EmployeeID) AS ManagerName,
				d.[Name] AS DepartmentName
	FROM Employees AS e
		JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID

--Task 11
SELECT TOP(1) AVG(e.Salary) AS MinAverageSalary
	FROM Employees AS e
	GROUP BY DepartmentID
	ORDER BY AVG(e.Salary) 
		
--Task 12
USE [Geography]

SELECT c.CountryCode,m.MountainRange,p.PeakName, p.Elevation
	FROM Peaks AS p
		JOIN Mountains AS m ON p.MountainId = m.Id
		JOIN MountainsCountries AS mk ON mk.MountainId = m.Id
		JOIN Countries AS c ON mk.CountryCode = c.CountryCode AND c.CountryCode = 'BG'
	WHERE p.Elevation > 2835
	ORDER BY p.Elevation DESC

--Task 13
SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainRanges
	FROM Mountains AS m
		JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
		JOIN Countries AS c ON c.CountryCode = mc.CountryCode
	WHERE c.CountryCode IN ('US', 'RU', 'BG')
	GROUP BY c.CountryCode

--Task 14
SELECT TOP(5) c.CountryName, r.RiverName
	FROM Countries AS c
		JOIN Continents AS con ON c.ContinentCode = con.ContinentCode
		LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
		LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	WHERE con.ContinentName = 'Africa'
	ORDER BY c.CountryName

--Task 15
SELECT con.ContinentCode, c.CurrencyCode
	FROM Continents AS con
		JOIN Countries AS c ON con.ContinentCode = c.ContinentCode 

--Task 16
SELECT COUNT(c.CountryCode) AS CountyCode
	FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode 
	WHERE mc.CountryCode IS NULL

--Task 17
SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.[Length]) AS LongestRiverLength
	FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p ON p.MountainId = m.Id 
		LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
		LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
	GROUP BY c.CountryName
	ORDER BY HighestPeakElevation DESC,
				LongestRiverLength DESC