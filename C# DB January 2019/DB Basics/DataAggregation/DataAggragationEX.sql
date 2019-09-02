--Task 1
USE Gringotts

SELECT COUNT(*) FROM WizzardDeposits

--Task 2
SELECT MAX(MagicWandSize) FROM WizzardDeposits

--Task 3
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
		GROUP BY DepositGroup

--Task 4
SELECT TOP(2) DepositGroup 
	FROM WizzardDeposits 
		GROUP BY DepositGroup
	ORDER BY AVG(MagicWandSize)

--Task 5
SELECT DISTINCT DepositGroup, SUM(DepositAmount) AS [TotalSum]
	 FROM WizzardDeposits
		GROUP BY DepositGroup

--Task 6
SELECT DISTINCT DepositGroup, SUM(DepositAmount) AS [TotalSum]
	 FROM WizzardDeposits
		WHERE MagicWandCreator = 'Ollivander family'
		GROUP BY DepositGroup

--Task 7
SELECT DISTINCT DepositGroup, SUM(DepositAmount) AS [TotalSum]
	FROM WizzardDeposits
		WHERE MagicWandCreator = 'Ollivander family' 
	GROUP BY DepositGroup
		HAVING SUM(DepositAmount) < 150000
	ORDER BY TotalSum DESC

--Task 8
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
	GROUP BY DepositGroup,MagicWandCreator
	ORDER BY MagicWandCreator
		, DepositGroup

--Task 9
SELECT 
		CASE	
			WHEN w.Age BETWEEN 0 AND 10
				THEN '[0-10]'
			WHEN w.Age BETWEEN 11 AND 20
				THEN '[11-20]'
			WHEN w.Age BETWEEN 21 AND 30
				THEN '[21-30]'
			WHEN w.Age BETWEEN 31 AND 40
				THEN '[31-40]'
			WHEN w.Age BETWEEN 41 AND 50
				THEN '[41-50]'
			WHEN w.Age BETWEEN 51 AND 60
				THEN '[51-60]'
			ELSE 
				'[61+]'
			END
				AS [AgeGroups],
		COUNT(*) AS [WizardCount]
	FROM WizzardDeposits AS w
		GROUP BY 
		CASE	
			WHEN w.Age BETWEEN 0 AND 10
				THEN '[0-10]'
			WHEN w.Age BETWEEN 11 AND 20
				THEN '[11-20]'
			WHEN w.Age BETWEEN 21 AND 30
				THEN '[21-30]'
			WHEN w.Age BETWEEN 31 AND 40
				THEN '[31-40]'
			WHEN w.Age BETWEEN 41 AND 50
				THEN '[41-50]'
			WHEN w.Age BETWEEN 51 AND 60
				THEN '[51-60]'
			ELSE 
				'[61+]'
			END
	
--Task 10
SELECT DISTINCT LEFT(FirstName,1) AS FirstLetter
	FROM WizzardDeposits
		WHERE DepositGroup = 'Troll Chest'
	GROUP BY LEFT(FirstName,1)
	ORDER BY FirstLetter

--Task 11
SELECT DepositGroup,IsDepositExpired, AVG(DepositInterest) AS AverageInterest
	FROM WizzardDeposits
		WHERE DepositStartDate > '01/01/1985'
	GROUP BY DepositGroup,
				IsDepositExpired
	ORDER BY DepositGroup DESC,
				IsDepositExpired

--Task 12
SELECT SUM(ws.Difference)
	FROM(
	SELECT DepositAmount - (
		SELECT DepositAmount
			FROM WizzardDeposits AS wsd
				WHERE wsd.Id = wd.Id + 1) AS Difference
		FROM WizzardDeposits AS wd) AS ws

--Task 13
USE SoftUni

SELECT DepartmentID, SUM(Salary) AS TotalSalary
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY DepartmentID

--Task 14
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
	FROM Employees
		WHERE HireDate > '01/01/2000'
	GROUP BY DepartmentID
		HAVING 	DepartmentID = 2 
				OR DepartmentID = 5 
				OR DepartmentID = 7

--Task 15
BACKUP DATABASE SoftUni TO DISK = 'D:\before_salary_increase.bak'

SELECT *
INTO NewTable 
	FROM Employees 
		WHERE Salary > 30000 

DELETE FROM NewTable
		WHERE ManagerID = 42

UPDATE NewTable
	SET Salary += 5000 
		WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
	FROM NewTable
	GROUP BY DepartmentID

DROP TABLE NewTable

--Task 16
SELECT DepartmentID, MAX(Salary) AS MaxSalary
	FROM Employees
	GROUP BY DepartmentID
		HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000 

--Task 17
SELECT COUNT(Salary) AS [Count]
	FROM Employees
		WHERE ManagerID IS NULL

--Task 18
SELECT salaries.DepartmentID, 
		salaries.Salary 
	FROM 
	(
		SELECT DepartmentID, 
			   Salary,
			   DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
			FROM Employees
			GROUP BY DepartmentID,
					 Salary
			) AS salaries
		WHERE Rank = 3
	GROUP BY salaries.DepartmentID, salaries.Salary

--Task 19
SELECT TOP(10) FirstName, LastName, DepartmentID
	FROM Employees AS e
		WHERE Salary > 
		( 
			SELECT AVG(Salary) 
				FROM Employees AS c
					WHERE e.DepartmentID = c.DepartmentID
		)
	ORDER BY DepartmentID
