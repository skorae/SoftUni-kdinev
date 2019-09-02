--Task 1
USE Demo

CREATE TABLE Passports(
PassportID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
PassportNumber NVARCHAR(8) NOT NULL)

CREATE TABLE Persons(
PersonID INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(20) NOT NULL,
Salary DECIMAL (15,2) NOT NULL,
PassportID INT UNIQUE
	CONSTRAINT FK_Passports_PassportID 
	FOREIGN KEY (PassportID) 
	REFERENCES Passports(PassportID) NOT NULL)

INSERT INTO Passports(PassportNumber) VALUES
('N34FG21B'),('K65LO4R7'),('ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID) VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101);

--Task 2
CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(20) UNIQUE NOT NULL,
EstablishedOn DATE NOT NULL)

CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
[Name] NVARCHAR(20) UNIQUE NOT NULL,
ManufacturerID INT FOREIGN KEY (ManufacturerID) 
	REFERENCES Manufacturers(ManufacturerID) NOT NULL)

INSERT INTO Manufacturers([Name], EstablishedOn) VALUES
('BMW','07/03/1916'),('Tesla', '01/01/2003'),('Lada', '01/05/1966')

INSERT INTO Models([Name],ManufacturerID) VALUES
('X1',1), ('i6', 1), ('Model S', 2), ('Model X', 2), ('Model 3', 2), ('Nova', 3)

--Task 3
CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(20) NOT NULL)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
[Name] NVARCHAR(20) NOT NULL)

CREATE TABLE StudentsExams(
StudentID INT FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
ExamID INT FOREIGN KEY (ExamID) REFERENCES Exams(ExamID),
PRIMARY KEY (StudentID,ExamID))

INSERT INTO Students([Name]) VALUES
('Mila'), ('Toni'), ('Ron')

INSERT INTO Exams([Name]) VALUES 
('SpringMVC'), ('Neo4j'), ('Oracle 11g')

INSERT INTO StudentsExams(StudentID,ExamID) VALUES 
(1,101), (1,102), (2,101), (3,103), (2,102), (2,103)

--Task 4
CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY IDENTITY(101,1),
[Name] NVARCHAR (20) NOT NULL,
ManagerID INT FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID))

INSERT INTO Teachers([Name], ManagerID) VALUES
('John',NULL), ('Maya',106), ('Silvia',106), ('Ted',105), ('Mark',101), ('Greta',101)

--Task 5
CREATE DATABASE OnlineStoreDatabase
GO

USE OnlineStoreDatabase

CREATE TABLE Cities(
CityID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
Birthday DATE NOT NULL,
CityID INT FOREIGN KEY (CityID) REFERENCES Cities(CityID) NOT NULL)

CREATE TABLE Orders(
OrderID INT PRIMARY KEY IDENTITY NOT NULL,
CustomerID INT FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) NOT NULL)

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL)

CREATE TABLE Items(
ItemID INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
ItemTypeID INT FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID) NOT NULL)

CREATE TABLE OrderItems(
OrderID INT FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) NOT NULL,
ItemID INT FOREIGN KEY (ItemID) REFERENCES Items(ItemID) NOT NULL,
PRIMARY KEY (OrderID,ItemID))

--Task 6
CREATE DATABASE UnivercityDatabase
GO

USE UnivercityDatabase

CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY IDENTITY,
SubjectName VARCHAR(50))

CREATE TABLE Majors(
MajorID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50))

CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY,
StudentNumber INT UNIQUE,
StudentName VARCHAR(50),
MajorID INT FOREIGN KEY(MajorID) REFERENCES Majors(MajorID))

CREATE TABLE Agenda(
StudentID INT FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
SubjectID INT FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID),
PRIMARY KEY (StudentID,SubjectID))

CREATE TABLE Payments(
PaymentID INT PRIMARY KEY IDENTITY,
PaymentDate DATE,
PaymentAmount DECIMAL (15,2),
StudentID INT FOREIGN KEY(StudentID) REFERENCES Students(StudentID))

--Task 9
USE [Geography]

SELECT m.MountainRange, p.PeakName, p.Elevation
	FROM Mountains AS m
		JOIN Peaks AS p ON p.MountainId = m.Id
		WHERE m.MountainRange = 'Rila'
	ORDER BY p.Elevation DESC

