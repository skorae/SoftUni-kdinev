--Task 1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
	SELECT e.FirstName, e.LastName
		FROM Employees AS e
			WHERE e.Salary > 35000
END
GO

--Task 2
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@salary DECIMAL(18,4))
AS
BEGIN
	SELECT e.FirstName, e.LastName
		FROM Employees AS e
			WHERE e.Salary >= @salary
END
GO

--Task 3
CREATE PROCEDURE usp_GetTownsStartingWith (@start VARCHAR(10))
AS
BEGIN
	SELECT t.[Name]
		FROM Towns AS T
			WHERE t.[Name] LIKE @start + '%'
END
GO

--Task 4
CREATE PROCEDURE usp_GetEmployeesFromTown (@townName VARCHAR(20))
AS
BEGIN
	SELECT e.FirstName, e.LastName
		FROM Employees AS e
			JOIN Addresses AS a ON e.AddressID = a.AddressID
			JOIN Towns AS t ON t.TownID = a.TownID
			WHERE t.[Name] LIKE @townName
END
GO

--Task 5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(10);
	
	IF (@salary < 30000)
		BEGIN
			SET @result = 'Low'
		END
	ELSE IF (@salary BETWEEN 30000 AND 50000)
		BEGIN
			SET @result = 'Average'
		END
	ELSE
		BEGIN
			SET @result = 'High'
		END
RETURN @result
END
GO

--Task 6
CREATE PROCEDURE usp_EmployeesBySalaryLevel (@salryLevel VARCHAR(10))
AS
BEGIN
	SELECT e.FirstName, e.LastName
		FROM Employees AS e
			WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salryLevel
END
GO

--Task 7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @count INT = 1;
	DECLARE @tempChar CHAR;

		WHILE (@count <= LEN(@word))
			BEGIN
				SET @tempChar = SUBSTRING(@word,@count,1);

				IF CHARINDEX(@tempChar,@setOfLetters,1) <= 0
					BEGIN
						RETURN 0
					END
				SET @count += 1;
			END
	RETURN 1
END
GO

--Task 8
BACKUP DATABASE SoftUni TO DISK = 'D:\Soft_Uni.bak'
GO

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment(@departmentId INT) 
AS
BEGIN
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT;

	DELETE FROM EmployeesProjects
		WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	UPDATE Departments
	SET ManagerID = NULL 
		WHERE DepartmentID = @departmentId

	UPDATE Employees
	SET ManagerID = NULL
		WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	DELETE FROM Employees
		WHERE DepartmentID = @departmentId

	DELETE FROM Departments 
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) - COUNT(*)
		FROM Employees
			WHERE DepartmentID = @departmentId;
END

--Task 9
USE Bank
GO

CREATE PROCEDURE usp_GetHoldersFullName 
AS
BEGIN
	SELECT CONCAT(ah.FirstName, ' ', ah.LastName) AS [Full Name]
		FROM AccountHolders AS ah
END
GO

--Task 10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@number MONEY)
AS
BEGIN
	SELECT n.FirstName, n.LastName
		FROM 
			(
				SELECT 
						FirstName, 
						LastName, 
						SUM(a.Balance) AS [Balance]
					FROM AccountHolders AS h
						JOIN Accounts AS a ON h.Id = a.AccountHolderId
					GROUP BY FirstName, LastName
			) AS n
			WHERE [Balance] > @number
		ORDER BY n.FirstName, n.LastName
END
GO

--Task 11
CREATE FUNCTION ufn_CalculateFutureValue (@sum MONEY, @interest FLOAT, @years INT)
RETURNS MONEY
AS 
BEGIN
	DECLARE @result MONEY = @sum * (POWER((1 + @interest), @years * 1.0))

	RETURN @result
END
GO

--Task 12
CREATE PROCEDURE usp_CalculateFutureValueForAccount (@AccountId INT , @interestRate FLOAT)
AS
BEGIN
	SELECT 
			a.Id AS AccountId,
			ah.FirstName AS [First Name],
			ah.LastName AS [Last Name],
			a.Balance AS [Current Balance],
			dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
		FROM AccountHolders AS ah
			JOIN Accounts AS a ON a.AccountHolderId = ah.Id
		WHERE a.Id = @AccountId
END
GO

--Task 13
USE Diablo
GO

CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(MAX))
RETURNS TABLE 
AS
	RETURN
	(
		SELECT SUM(game.Cash) AS SumCash
			FROM (
					SELECT 
							g.[Name],
							ug.Cash,
							ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS rn
						FROM Games AS g
							JOIN UsersGames AS ug ON ug.GameId = g.Id
							WHERE g.[Name] = @gameName
					) AS game
			WHERE game.rn % 2 != 0
	)

USE Bank
CREATE TABLE Logs
	(
		LogId INT PRIMARY KEY IDENTITY, 
		AccountId INT FOREIGN KEY(AccountId) REFERENCES Accounts(Id) NOT NULL,
		OldSum DECIMAL(15,2) NOT NULL, 
		NewSum DECIMAL(15,2) NOT NULL
	);

--Task 14
CREATE TRIGGER tr_Change_Balance ON Accounts FOR UPDATE
AS
	INSERT INTO Logs VALUES
		(
			(SELECT Id FROM deleted),
			(SELECT Balance FROM deleted),
			(SELECT Balance FROM inserted)
		)

--Task 15
CREATE TABLE NotificationEmails
	(
		Id        INT PRIMARY KEY IDENTITY,
		Recipient INT NOT NULL,
		[Subject]   NVARCHAR(50) NOT NULL,
		Body      NVARCHAR(255) NOT NULL
	);

CREATE TRIGGER tr_Notification_Email ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails VALUES
	 (
         (SELECT AccountId FROM inserted),
         CONCAT('Balance change for account: ',(SELECT AccountId FROM inserted)),
         CONCAT('On ', FORMAT(GETDATE(), 'dd-MM-yyyy HH:mm'), ' your balance was changed from ',
				(SELECT OldSum FROM Logs), ' to ', (SELECT NewSum FROM Logs), '.')
	);

--Task 16
CREATE PROCEDURE usp_DepositMoney (AccountId, MoneyAmount)