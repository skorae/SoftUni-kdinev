CREATE DATABASE Supermarket 
GO

USE Supermarket

--Task 1
CREATE TABLE Categories
	(
		Id		INT PRIMARY KEY IDENTITY,
		[Name]	NVARCHAR(30) NOT NULL
	);

CREATE TABLE Items
	(
		Id			INT PRIMARY KEY IDENTITY,
		[Name]		NVARCHAR(30) NOT NULL,
		Price		DECIMAL(15,2) NOT NULL,
		CategoryId	INT FOREIGN KEY(CategoryId) REFERENCES Categories(Id) NOT NULL
	);

CREATE TABLE Employees
	(
		Id			INT PRIMARY KEY IDENTITY,
		FirstName	NVARCHAR(50) NOT NULL,
		LastName	NVARCHAR(50) NOT NULL,
		Phone		VARCHAR(12) NOT NULL,
		Salary		DECIMAL(15,2) NOT NULL,
		CONSTRAINT CK_Phone CHECK(LEN(Phone) = 12)
	);

CREATE TABLE Orders
	(
		Id			INT PRIMARY KEY IDENTITY,
		DateTime	DATETIME NOT NULL,
		EmployeeId	INT FOREIGN KEY(EmployeeId) REFERENCES Employees(Id) NOT NULL
	);

CREATE TABLE OrderItems
	(
		OrderId		INT FOREIGN KEY(OrderId) REFERENCES Orders(Id) NOT NULL,
		ItemId		INT FOREIGN KEY(ItemId) REFERENCES Items(Id) NOT NULL,
		Quantity	INT NOT NULL,
		PRIMARY KEY(OrderId, ItemId),
		CONSTRAINT CK_Quantity CHECK(Quantity > 0)
	);

CREATE TABLE Shifts
	(
		Id			INT IDENTITY,
		EmployeeId	INT FOREIGN KEY(EmployeeId) REFERENCES Employees(Id) NOT NULL,
		CheckIn		DATETIME NOT NULL,
		CheckOut	DATETIME NOT NULL,
		PRIMARY KEY(Id,EmployeeId),
		CONSTRAINT CK_Check_Out CHECK(CheckOut > CheckIn)
	);

--Task 2
INSERT INTO Employees 
					(
						FirstName,
						LastName, 
						Phone, 
						Salary
					) 
		VALUES
			(
				'Stoyan', 
				'Petrov',
				'888-785-8573', 
				500.25
			),

			(
				'Stamat', 
				'Nikolov', 
				'789-613-1122', 
				999995.25
			),

			(
				'Evgeni',
				'Petkov', 
				'645-369-9517', 
				1234.51
			),

			(
				'Krasimir', 
				'Vidolov', 
				'321-471-9982', 
				50.25
			);

INSERT INTO Items 
				(
					[Name],
					Price,
					CategoryId
				)
		VALUES
				(
					'Tesla battery',	
					154.25,	
					8 
				),

				(
					'Chess',	
					30.25,	
					8		  
				),

				(
					'Juice',	
					5.32,	
					1		  
				),

				(
					'Glasses',	
					10,
					8		  
				),

				(
					'Bottle of water',	
					1,	
					1 
				);

--Task 3
BACKUP DATABASE Supermarket TO DISK = 'D:\Supermarket_Before_Update.bak';

UPDATE Items
	SET Price *= 1.27
		WHERE CategoryId IN (1,2,3);

--Task 4
BACKUP DATABASE Supermarket TO DISK = 'D:\Supermarket_Before_DELETE.bak';

DELETE FROM OrderItems 
		WHERE OrderId = 48

--Task 5
SELECT e.Id, e.FirstName
	FROM Employees AS e
		WHERE Salary > 6500
ORDER BY e.FirstName, e.Id

--Task 6
SELECT 
		CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name], 
		e.Phone AS [Phone Number]
	FROM Employees AS e
		WHERE e.Phone LIKE '3%'
ORDER BY e.FirstName, [Phone Number]

--Task 7
SELECT e.FirstName, e.LastName, COUNT(*) AS [Count]
	FROM Employees AS e
		JOIN Orders AS o ON o.EmployeeId = e.Id
	GROUP BY e.FirstName, e.LastName
ORDER BY [Count] DESC, e.FirstName

--Task 8
SELECT e.FirstName, e.LastName, AVG(DATEDIFF(HOUR, sh.CheckIn, sh.CheckOut)) AS WorkHours
	FROM Employees AS e
		JOIN Shifts AS sh ON sh.EmployeeId = e.Id
	GROUP BY e.Id, e.FirstName, e.LastName
		HAVING AVG(DATEDIFF(HOUR, sh.CheckIn, sh.CheckOut)) > 7
ORDER BY WorkHours DESC , e.Id

--Task 9
SELECT TOP(1) oi.OrderId, SUM(i.Price * oi.Quantity) AS TotalPrice
	FROM OrderItems AS oi 
		JOIN Items AS i ON oi.ItemId = i.Id
	GROUP BY oi.OrderId
ORDER BY TotalPrice DESC
--Task 10
SELECT TOP (10) o.Id, MAX(i.Price) AS ExpensivePrice, MIN(i.Price) AS CheapPrice
	FROM Orders AS o
		JOIN OrderItems AS oi ON o.Id = oi.OrderId
		JOIN Items AS i ON oi.ItemId = i.Id
	GROUP BY o.Id
ORDER BY ExpensivePrice DESC, o.Id

--Task 11
SELECT DISTINCT e.Id, e.FirstName, e.LastName
	FROM OrderItems AS oi
		JOIN Orders AS o ON oi.OrderId = o.Id 
		JOIN Employees AS e ON o.EmployeeId = e.Id
ORDER BY e.Id

--Task 12
SELECT e.Id, CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name]
	FROM Employees AS e
		JOIN Shifts AS s ON s.EmployeeId = e.Id
	GROUP BY e.Id, DATEDIFF(HOUR,s.CheckIn, s.CheckOut),CONCAT(e.FirstName, ' ', e.LastName)
		HAVING DATEDIFF(HOUR,s.CheckIn, s.CheckOut) < 4
ORDER BY e.Id

--Task 13
SELECT TOP(10)
		CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
		SUM(i.Price * oi.Quantity) AS [Total Price],
		SUM(oi.Quantity) AS [Items]
	FROM Employees AS e
		JOIN Orders AS o ON e.Id = o.EmployeeId
		JOIN OrderItems AS oi ON o.Id = oi.OrderId
		JOIN Items AS i ON i.Id = oi.ItemId
		WHERE o.[DateTime] < '2018-06-15'
	GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY [Total Price] DESC, [Items] DESC

--Task 14
SELECT 
		CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
		DATENAME(WEEKDAY,s.CheckIn) AS [Day of week]
	FROM Employees AS e
		LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
		JOIN Shifts AS s ON s.EmployeeId = e.Id
		WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12 AND o.Id IS NULL
ORDER BY e.Id

--Task 15
SELECT 
		emp.FirstName + ' ' + emp.LastName AS [Full Name],
		DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours,
		e.TotalPrice AS TotalPrice
	FROM
		(
			SELECT 
					o.EmployeeId,
					SUM(oi.Quantity * i.Price) AS TotalPrice,
					o.DateTime,
					ROW_NUMBER() OVER (PARTITION BY o.EmployeeId 
					ORDER BY o.EmployeeId, SUM(i.Price * oi.Quantity) DESC) AS Rank
				FROM Orders AS o
					JOIN OrderItems AS oi ON oi.OrderId = o.Id
					JOIN Items AS i ON i.Id = oi.ItemId
				GROUP BY o.EmployeeId, o.Id, o.DateTime
		) AS e
		JOIN Employees AS emp ON emp.Id = e.EmployeeId
		JOIN Shifts AS s ON s.EmployeeId = e.EmployeeId
		WHERE e.Rank = 1 AND e.DateTime BETWEEN s.CheckIn AND s.CheckOut
ORDER BY [Full Name], WorkHours DESC, TotalPrice DESC

--Task 16
SELECT 
		DATEPART(DAY, o.DateTime) AS [Day],
		CAST(AVG(i.Price * oi.Quantity) AS DECIMAL(15,2)) AS TotalPrice
	FROM Orders AS o
		JOIN OrderItems AS oi ON oi.OrderId = o.Id
		JOIN Items AS i ON i.Id = oi. ItemId
	GROUP BY DATEPART(DAY, o.DateTime)
ORDER BY [Day]

--Task 17
SELECT 
		i.[Name]					AS Item, 
		c.[Name]					AS Category, 
		SUM(oi.Quantity)			AS [Count], 
		SUM(oi.Quantity * i.Price)	AS TotalPrice
	FROM Items AS i
		JOIN Categories AS c ON i.CategoryId = c.Id
		LEFT JOIN OrderItems AS oi ON oi.ItemId = i.Id
	GROUP BY i.[Name], c.[Name]
ORDER BY TotalPrice DESC, [Count] DESC

--Task 18
CREATE FUNCTION udf_GetPromotedProducts
		(
		@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, 
		@Discount DECIMAL(15,2), 
		@FirstItemId INT, @SecondItemId INT, @ThirdItemId INT
		)
RETURNS VARCHAR(MAX)
BEGIN
		DECLARE @FirstItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
		DECLARE @SecondItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
		DECLARE @ThirdItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

		IF(@FirstItemName IS NULL OR @SecondItemName IS NULL OR @ThirdItemName IS NULL)
			BEGIN
				RETURN 'One of the items does not exists!'
			END

		IF (@CurrentDate NOT BETWEEN @StartDate AND @EndDate)
			BEGIN
				RETURN 'The current date is not within the promotion dates!'
			END

		DECLARE @FirstPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
		DECLARE @SecondPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
		DECLARE @ThirdPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)

		SET @FirstPrice = @FirstPrice - ((@FirstPrice * @Discount) / 100)
		SET @SecondPrice = @SecondPrice - ((@SecondPrice * @Discount) / 100)
		SET @ThirdPrice = @ThirdPrice - ((@ThirdPrice * @Discount) / 100)

		RETURN	@FirstItemName + ' price: ' + CAST(@FirstPrice AS VARCHAR) + ' <-> ' +
				@SecondItemName + ' price: ' + CAST(@SecondPrice AS VARCHAR) + ' <-> ' +
				@ThirdItemName + ' price: ' + CAST(@ThirdPrice AS VARCHAR)
END

--Task 19
CREATE PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)
AS
	DECLARE @order INT = (SELECT Id FROM Orders WHERE Id = @OrderId)

	IF (@order IS NULL)
	BEGIN
			RAISERROR ('The order does not exist!', 16, 1)
			RETURN
	END

	DECLARE @date DATETIME = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)

	IF (DATEDIFF(DAY,@date, @CancelDate) > 3)
	BEGIN
			RAISERROR ('You cannot cancel the order!',16,1)
			RETURN
	END

	DELETE FROM OrderItems
		WHERE OrderId = @OrderId

	DELETE FROM Orders
		WHERE Id = @OrderId

--Task 20
CREATE TRIGGER tr_Trigger_On_Delete ON OrderItems FOR DELETE
AS
INSERT INTO DeletedOrders (OrderId, ItemId, ItemQuantity) 
	SELECT OrderId,ItemId, Quantity FROM deleted

