--Task 2
USE SoftUni

SELECT * FROM Departments

--Task 3
SELECT [Name] FROM Departments

--Task 4
SELECT FirstName,LastName, Salary FROM Employees

--Task 5
SELECT FirstName,MiddleName,LastName FROM Employees

--Task 6
SELECT FirstName + '.' + LastName + '@softuni.bg' AS 'Full Email Address'
		FROM Employees

--Task 7
SELECT DISTINCT Salary FROM Employees 

--Task 8
SELECT * FROM Employees WHERE JobTitle = 'Sales Representative'

--Task 9
SELECT FirstName,LastName,JobTitle 
	FROM Employees 
		WHERE Salary BETWEEN 20000 AND 30000; 

--Task 10
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS 'Full Name' 
	FROM Employees
		WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600 

--Task 11

SELECT FirstName,LastName 
	FROM Employees 
		WHERE ManagerID IS NULL

--Task 12
SELECT FirstName,LastName,Salary 
	FROM Employees
		WHERE Salary > 50000
	ORDER BY Salary DESC

--Task 13
SELECT TOP(5) FirstName,LastName 
	FROM Employees
ORDER BY Salary DESC

--Task 14
SELECT FirstName,LastName
	 FROM Employees
		WHERE DepartmentID <> 4

--Task 15
SELECT * FROM Employees 
		ORDER BY Salary DESC 
				 ,FirstName
				 ,LastName DESC
				 ,MiddleName;
			
--Task 16
CREATE VIEW V_EmployeesSalaries AS 

SELECT FirstName,LastName,Salary FROM Employees

--Task 17
CREATE VIEW V_EmployeeNameJobTitle AS
	SELECT FirstName + ' ' + ISNULL(MiddleName + ' ','') + LastName AS 'Full Name',
			JobTitle AS 'Job Title'
		FROM Employees

--Task 18
SELECT DISTINCT JobTitle 
	FROM Employees

--Task 19
SELECT TOP(10) * FROM Projects
	ORDER BY StartDate,[Name]

--Task 20
SELECT TOP(7) FirstName,LastName,HireDate 
	FROM Employees
		ORDER BY HireDate DESC

--Task 21
BACKUP DATABASE SoftUni TO DISK = 'D:\EmplyeesBackup.bak'

UPDATE Employees 
	SET Salary *= 1.12
			WHERE DepartmentID IN 
				(SELECT DepartmentID FROM Departments
					WHERE [Name] = 'Engineering'
					OR [Name] = 'Tool Design'
					OR [Name] = 'Marketing' 
					OR [Name] = 'Information Services')

SELECT Salary FROM Employees

USE master
DROP DATABASE SoftUni

RESTORE DATABASE SoftUni FROM DISK = 'D:\EmplyeesBackup.bak'