CREATE DATABASE Minions

USE Minions

CREATE TABLE Minions(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL
)

ALTER TABLE Minions
ADD TownId INT CONSTRAINT FK_TowsId_Towns FOREIGN KEY REFERENCES Towns(Id)

SET IDENTITY_INSERT Towns OFF

SET IDENTITY_INSERT Minions ON

INSERT INTO Towns (Id,[Name])
VALUES (1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id,[Name],Age,TownId)
VALUES (1,'Kevin' ,22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

DROP TABLE Minions
DROP TABLE Towns
DROP TABLE PEOPLE

--Task 7
CREATE TABLE People
(
             Id        INT
             UNIQUE IDENTITY NOT NULL,
             Name      NVARCHAR(200) NOT NULL,
             Picture   VARBINARY(MAX),
             Height    NUMERIC(3, 2),
             Weight    NUMERIC(5, 2),
             Gender    CHAR(1) CHECK([Gender] IN('M', 'F')) NOT NULL,
             Birthdate DATE NOT NULL,
             Biography NVARCHAR(MAX)
);

ALTER TABLE People
ADD PRIMARY KEY(Id);

ALTER TABLE People
ADD CONSTRAINT CH_PictureSize CHECK(DATALENGTH(Picture) <= 2 * 1024 * 1024);

INSERT INTO People(Name,
                   Gender,
                   Birthdate
                  )
VALUES
(
       'First Name',
       'M',
       '01-01-2000'
),
(
       'Second Name',
       'F',
       '05-03-2001'
),
(
       'Third Name',
       'F',
       '07-08-2005'
),
(
       'Fourth Name',
       'F',
       '03-05-2007'
),
(
       'Fifth Name',
       'M',
       '08-09-2003'
);
-- End Task 7

--Task 8
CREATE TABLE Users(
Id BIGINT UNIQUE IDENTITY NOT NULL,
Username VARCHAR (30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME2,
IsDeleted BIT DEFAULT(0)
);

ALTER TABLE Users 
ADD CONSTRAINT PK_Users PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CH_ProfilePicture CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024);

INSERT INTO Users (Username, [Password]) 
VALUES 
('pesho','gdsgf'),
('gosho','fdsfg'),
('fdsf','gfdg'),
('fadsf','jhjgdh'),
('fgsfgwer','fsgdfhdg');


--Tast 9

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_User PRIMARY KEY (Id,Username)

--Tast 10

ALTER TABLE Users
ADD CONSTRAINT [Password] CHECK(LEN([Password]) >= 5);

--Task 11
ALTER TABLE Users
ADD CONSTRAINT DF_Users DEFAULT GETDATE() FOR LastLoginTime

--Task 12

ALTER TABLE Users
DROP CONSTRAINT PK_User

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id)

ALTER TAbLE Users
ADD CONSTRAINT Username CHECK(LEN(Username) >= 3) 

--Task 13
CREATE DATABASE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY NOT NULL,
DirectorName VARCHAR(50) UNIQUE NOT NULL,
Notes VARCHAR (MAX))

CREATE TABLE Genres (
Id INT PRIMARY KEY IDENTITY NOT NULL,
GenreName VARCHAR(20) UNIQUE NOT NULL,
Notes VARCHAR (MAX))

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY NOT NULL,
CategoryName VARCHAR(20) UNIQUE NOT NULL,
Notes VARCHAR(MAX))

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Title VARCHAR(50) UNIQUE NOT NULL,
DirectorId INT FOREIGN KEY(DirectorId) REFERENCES Directors(Id),
CopyrightYear DATE NOT NULL,
[Length] INT NOT NULL,
GenreId INT FOREIGN KEY (GenreId) REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
Rating INT CHECK (Rating <= 10 AND Rating > 1),
Notes TEXT)

INSERT INTO Directors (DirectorName) VALUES
('pesho'),('gosho'),('stamat'),('grigor'),('grisha');

INSERT INTO Genres (GenreName) VALUES
('action'),('comedy'),('horror'),('parody'),('Sci-Fy');

InSERT INTO Categories (CategoryName) VALUES
('show'),('standUp'),('movie'),('telenovela'),('documetary');

INSERT INTO Movies (Title,DirectorId,CopyrightYear,Length,GenreId,CategoryId) VALUES
('DEBRE',1,'2004-11-11',23,1,1)
,('UMBRE',2,'2004-11-11',23,2,2)
,('HUMBRE',3,'2004-11-11',23,3,3)
,('ABRE',4,'2004-11-11',23,4,4)
,('OIBRE',5,'2004-11-11',23,5,5);

--Tast 14
CREATE DATABASE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY NOT NULL,
CategoryName VARCHAR (10) NOT NULL,
DailyRate MONEY,
WeeklyRate MONEY,
MonthlyRate MONEY,
WeekendRate MONEY);

INSERT INTO Categories (CategoryName) VALUES 
('SUV'),('Sedan'),('Salon');

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY NOT NULL,
PlateNumber NVARCHAR(6) NOT NULL,
Manufacturer NVARCHAR(20) NOT NULL,
Model NVARCHAR (10) NOT NULL,
CarYear DATE,
CategoryId INT FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
Doors INT,
Picture VARBINARY (MAX),
Condition CHAR(10),
Available BINARY DEFAULT (0));

INSERT INTO Cars (PlateNumber,Manufacturer,Model,CategoryId) VALUES
('CA1111','BMW','X5',1)
,('CA1112','AUDI','A4',2)
,('CA1113','BMW','M5',3);

CREATE TABLE Employees (
Id INT IDENTITY PRIMARY KEY NOT NULL,
FirstName VARCHAR (10) NOT NULL,
LastName VARCHAR(10) NOT NULL,
Title VARCHAR (15) NOT NULL,
Notes VARCHAR(MAX));

INSERT INTO Employees (FirstName,LastName,Title) VALUES
('pesho','peshev','worker')
,('gosho','goshev','high worker')
,('stamat','stamatov','low worker');

CREATE TABLE Customers(
Id INT IDENTITY PRIMARY KEY NOT NULL,
DriverLicenceNumber INT UNIQUE NOT NULL,
FullName VARCHAR (30) NOT NULL,
Address VARCHAR(50) NOT NULL,
City VARCHAR (20) NOT NULL,
ZIPCode INT NOT NULL,
Notes VARCHAR (50));

INSERT INTO Customers (DriverLicenceNumber,FullName,Address,City,ZIPCode) VALUES
(234323123,'prodan prodanov','zelksa street','Sofia',1730),
(343214,'gosho goshev','petel street','plovdiv',2040),
(44324,'bogdan bogdanov','top street','varna',5040);

CREATE TABLE RentalOrders(
Id INT IDENTITY PRIMARY KEY NOT NULL,
EmployeeId INT FOREIGN KEY (EmployeeId) REFERENCES Employees(Id) NOT NULL,
CustomerId INT FOREIGN KEY (CustomerId) REFERENCES Customers(Id) NOT NULL,
CarId INT FOREIGN KEY (CarId) REFERENCES Cars(Id) NOT NULL,
TankLevel INT NOT NULL,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage INT NOT NULL, 
StartDate DATE NOT NULL, 
EndDate DATE NOT NULL,
TotalDays INT NOT NULL, 
RateApplied MONEY,
TaxRate MONEY,
OrderStatus BINARY DEFAULT (0),
Notes VARCHAR (50));

INSERT INTO RentalOrders (
	EmployeeId
	,CustomerId
	,CarId
	,TankLevel
	,KilometrageStart
	,KilometrageEnd
	,TotalKilometrage
	,StartDate
	,EndDate
	,TotalDays)
 VALUES
	(1,1,1,40,100,200,100, '2000-11-11','2000-11-12',1)
	,(2,2,2,50,300,500,200, '2000-11-13','2000-11-15',2)
	,(3,3,3,30,50,500,450, '2000-11-10','2000-11-15',5);
	
--Task 15

CREATE DATABASE Hotel
GO

USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(10) NOT NULL,
LastName VARCHAR(10) NOT NULL,
Title VARCHAR(20),
Notes VARCHAR(max));

INSERT INTO Employees (FirstName,LastName) VALUES
('pesho','peshov'),
('gosho','goshov'),
('stamat', 'stamatov');

CREATE TABLE Customers(
AccountNumber INT  PRIMARY KEY IDENTITY,
FirstName VARCHAR(10) NOT NULL,
LastName VARCHAR (10) NOT NULL,
Phonenumber INT NOT NULL,
EmergencyName VARCHAR (20) NOT NULL,
EmergencyNumber INT NOT NULL,
Notes VARCHAR(MAX));

INSERT INTO Customers (FirstName,LastName,Phonenumber,EmergencyName,EmergencyNumber) VALUES
('pesho','geshov', 3123432,'Prodan Prodanov',34234),
('gosho','peshov',12345,'Gincho penchov',643211),
('stamat', 'lambov',22222,'goran granchov',433525245);


CREATE TABLE RoomStatus(
RoomStatus VARCHAR (10) PRIMARY KEY NOT NULL,
Notes VARCHAR(MAX));

INSERT INTO RoomStatus (RoomStatus) VALUES 
('free'),('occupied'),('reserved');

CREATE TABLE RoomTypes(
RoomType VARCHAR (10) PRIMARY KEY,
Notes VARCHAR(MAX))

INSERT INTO RoomTypes(RoomType) VALUES 
('single'),('double'),('tripple');

CREATE TABLE BedTypes (
BedType VARCHAR (10) PRIMARY KEY,
Notes VARCHAR (MAX));

INSERT INTo BedTypes (BedType) VALUES
('single'),('kingSize'),('queensize');

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY IDENTITY,
RoomType VARCHAR(10) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
BedType VARCHAR (10) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
Rate MONEY,
RoomStatus VARCHAR (10) FOREIGN KEY REFERENCES RoomStatus (RoomStatus) NOT NULL,
Notes VARCHAR (MAX));

INSERT INTO Rooms (RoomType,BedType,RoomStatus) VALUES 
('single','single','free'),
('double','kingSize','free'),
('tripple','queensize','free');

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE NOT NULL,
AccountNumber INT NOT NULL,
FirstDateOccupied DATE NOT NULL,
LastDateOccupied  DATE NOT NULL,
TotalDays INT NOT NULL,
AmountCharged DECIMAL(10, 2) NOT NULL,
TaxRate DECIMAL(15, 2) NOT NULL,
TaxAmount DECIMAL(15, 2) NOT NULL,
PaymentTotal DECIMAL(15, 2) NOT NULL,
Notes NVARCHAR(MAX));

ALTER TABLE Payments
ADD CONSTRAINT CK_TotalDays CHECK(DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied) = TotalDays);

ALTER TABLE Payments
ADD CONSTRAINT CK_TaxAmount CHECK(TaxAmount = TotalDays * TaxRate);

INSERT INTO Payments (EmployeeId,
                     PaymentDate,
                     AccountNumber,
                     FirstDateOccupied,
                     LastDateOccupied,
                     TotalDays,
                     AmountCharged,
                     TaxRate,
                     TaxAmount,
                     PaymentTotal) 
VALUES
(1,'10-05-2015',1,'10-05-2015','10-10-2015', 5,75,50,250, 75),
(3,'10-11-2015', 1, '12-15-2015','12-25-2015',10,100,50,500,100),
(2,'12-23-2015',1,'12-23-2015','12-24-2015',1,75,75,75,75);

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
DateOccupied DATE NOT NULL,
AccountNumber INT NOT NULL,
RoomNumber INT NOT NULL,
RateApplied DECIMAL(15, 2),
PhoneCharge VARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX));

INSERT INTO Occupancies(EmployeeId,DateOccupied, AccountNumber, RoomNumber, PhoneCharge) VALUES
(2,'08-24-2012', 3,1, '088 88 888 888'),
(3,'06-15-2015',2,3, '088 88 555 555'),
(1,'05-12-1016',1, 2,'088 88 555 333');

--Task 16

CREATE DATABASE SoftUni
GO

USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL);

CREATE TABLE Addresses (
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(50) NOT NULL, 
TownId INT FOREIGN KEY REFERENCES Towns(Id));

CREATE TABLE Departments (
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL);

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY,
 FirstName NVARCHAR(50) NOT NULL, 
 MiddleName NVARCHAR(50) NOT NULL, 
 LastName NVARCHAR(50) NOT NULL, 
 JobTitle NVARCHAR(50) NOT NULL, 
 DepartmentId INT FOREIGN KEY REFERENCES Departments(Id), 
 HireDate DATE, 
 Salary DECIMAL (15,2) NOT NULL, 
 AddressId INT FOREIGN KEY REFERENCES Addresses(Id));

 --Task 17

 BACKUP DATABASE SoftUni TO DISK = 'D:\softuni-backup.bak'

 USE Minions

 DROP DATABASE SoftUni

 RESTORE DATABASE softUni FROM DISK = 'C:\Users\skora\Desktop\softuni-backup.bak'

 --Tast 18
 USE SoftUni

 INSERT INTO Towns ([Name]) VALUES
 ('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas');

 INSERT INTO Departments([Name]) VALUES
('Engineering'), ('Sales'), ('Marketing'),('Software Development'), ('Quality Assurance');

INSERT INTO	Employees(FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary) VALUES 
('Ivan', 'Ivanov','Ivanov', '.NET Developer',  4, CONVERT(DATE, '02/03/2004', 103), 3500.00),
('Petar','Petrov', 'Petrov', 'Senior Engineer',  1, CONVERT(DATE, '02/03/2004', 103), 4000.00),
('Maria', 'Petrova',  'Ivanova', 'Intern', 5, CONVERT(DATE, '28/08/2016', 103), 525.25),
('Georgi','Teziev ', 'Ivanov','CEO', 2, CONVERT(DATE, '09/12/2007', 103),000.00),
( 'Peter','Pan ', 'Pan', 'Intern', 3, CONVERT(DATE, '28/08/2016', 103),599.88);

--Task 19

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--Task 20

SELECT * FROM Towns ORDER BY [Name]

SELECT * FROM Departments ORDER BY [Name]

SELECT * FROM Employees ORDER BY Salary DESC

--Task 21

SELECT [Name] FROM Towns ORDER BY [Name]

SELECT [Name] FROM Departments ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

--Task 22

UPDATE Employees SET Salary *= 1.1;

SELECT Salary FROM Employees

--Task 23

USE Hotel
UPDATE Payments SET TaxRate *= 0.97

SELECT TaxRate FROM Payments

--Task 24

TRUNCATE TABLE Occupancies 