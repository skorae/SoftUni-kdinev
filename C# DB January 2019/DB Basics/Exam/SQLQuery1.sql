USE master
DROP DATABASE School
CREATE DATABASE School
GO

USE School

--Task 1
CREATE TABLE Students
	(
		Id			INT PRIMARY KEY IDENTITY,
		FirstName	NVARCHAR(30) NOT NULL,
		MiddleName	NVARCHAR(25),
		LastName	NVARCHAR(30) NOT NULL,
		Age			INT NOT NULL,	
		[Address]	NVARCHAR(50),
		Phone		NCHAR(10),
		CONSTRAINT CK_Check_Age CHECK(Age BETWEEN 5 AND 100)
	);

CREATE TABLE Subjects
	(
		Id		INT PRIMARY KEY IDENTITY,
		[Name]	NVARCHAR(20) NOT NULL,
		Lessons	INT NOT NULL,
		CONSTRAINT CK_Check_Lessons CHECK(Lessons > 0)
	);

CREATE TABLE StudentsSubjects
	(
		Id			INT PRIMARY KEY IDENTITY,
		StudentId	INT FOREIGN KEY(StudentId) REFERENCES Students(Id) NOT NULL,
		SubjectId	INT FOREIGN KEY(SubjectId) REFERENCES Subjects(Id) NOT NULL,
		Grade	DECIMAL(15,2) NOT NULL,
		CONSTRAINT CK_Grade CHECK(Grade BETWEEN 2 AND 6)
	);

CREATE TABLE Exams
	(
		Id	INT PRIMARY KEY IDENTITY,
		[Date]	DATETIME,
		SubjectId	INT FOREIGN KEY(SubjectId) REFERENCES Subjects(Id) NOT NULL
	);

CREATE TABLE StudentsExams
	(
		StudentId	INT FOREIGN KEY(StudentId) REFERENCES Students(Id) NOT NULL,
		ExamId		INT FOREIGN KEY(ExamId) REFERENCES Exams(Id) NOT NULL,
		Grade		DECIMAL(15,2) NOT NULL,
		PRIMARY KEY(StudentId, ExamId),
		CONSTRAINT CK_Grade_Exam CHECK(Grade BETWEEN 2 AND 6)
	);

CREATE TABLE Teachers
	(
		Id	INT PRIMARY KEY IDENTITY,
		FirstName	NVARCHAR(20) NOT NULL,
		LastName	NVARCHAR(20) NOT NULL,
		[Address]	NVARCHAR(20) NOT NULL,
		Phone	CHAR(10),
		SubjectId	INT FOREIGN KEY(SubjectId) REFERENCES Subjects(Id) NOT NULL
	);

CREATE TABLE StudentsTeachers
	(
		StudentId	INT FOREIGN KEY(StudentId) REFERENCES Students(Id) NOT NULL,
		TeacherId	INT FOREIGN KEY(TeacherId) REFERENCES Teachers(Id) NOT NULL,
		PRIMARY KEY (StudentId, TeacherId)
	);

BACKUP DATABASE School TO DISK = 'D:\Shcool.bak'

--Task 2
INSERT INTO Teachers(FirstName, LastName, Address, Phone, SubjectId) VALUES
	('Ruthanne'	,'Bamb'	,'84948 Mesta Junction',	'3105500146',	6  ),
	('Gerrard'	,'Lowin',	'370 Talisman Plaza',	'3324874824',	2	   ),
	('Merrile'	,'Lambdin','	81 Dahle Plaza',	'4373065154',	5		   ),
	('Bert',	'Ivie',	'2 Gateway Circle',	'4409584510',	4		   );

INSERT INTO Subjects (Name, Lessons) VALUES
	('Geometry',	12 ),
	('Health',	10 ),
	('Drama',	7	   ),
	('Sports',	9  );

--Tak 3
UPDATE StudentsSubjects
	SET Grade = 6.00
		WHERE SubjectId IN (1,2) AND Grade >= 5.50 

--Task 4
DELETE FROM StudentsTeachers WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
	WHERE Phone LIKE '%72%'

RESTORE DATABASE School FROM DISK = 'D:\Shcool.bak'
GO
USE School

--Task 5
SELECT s.FirstName, s.LastName, s.Age
	FROM Students AS s
		WHERE s.Age >= 12
ORDER BY s.FirstName, s.LastName

--Task 6
SELECT (CASE
			WHEN s.MiddleName IS NULL
				THEN s.FirstName + '  ' + s.LastName
			ELSE s.FirstName + ' ' + s.MiddleName + ' ' + s.LastName
		END) AS FullName,
		s.[Address]
	FROM Students AS s
		WHERE s.Address LIKE '%road%'
ORDER BY s.FirstName, s.LastName, s.Address

--Task 7
SELECT s.FirstName, s.Address, s.Phone
	FROM Students AS s
		WHERE s.MiddleName IS NOT NULL AND Phone LIKE '42%'
ORDER BY s.FirstName

--Task 8
SELECT s.FirstName, s.LastName, COUNT(st.TeacherId)
	FROM Students AS s
		JOIN StudentsTeachers AS st ON st.StudentId = s.Id
	GROUP BY s.FirstName, s.LastName

--Task 9
SELECT
		CONCAT(b.FirstName, ' ', b.LastName) AS FullName,
		CONCAT(b.SubjectName, '-', b.subjectLessons) AS Subjects,
		b.StudentsCount AS StudentsCount
	FROM 
		(SELECT 
				t.FirstName AS FirstName, 
				t.LastName AS LastName, 
				COUNT(st.StudentId) AS StudentsCount,
				sub.[Name] AS SubjectName,
				sub.Lessons AS subjectLessons
			FROM Teachers AS t
				JOIN Subjects AS sub ON t.SubjectId = sub.Id
				JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
				GROUP BY t.FirstName, t.LastName, sub.Name, sub.Lessons
		) AS b 
ORDER BY StudentsCount DESC

--Task 10
SELECT CONCAT(s.FirstName, ' ', s.LastName) AS FullName
	FROM StudentsExams AS se
		FULL JOIN Students AS s ON se.StudentId = s.Id
		WHERE se.StudentId IS NULL
ORDER BY FullName

--Task 11
SELECT TOP(10) t.FirstName, t.LastName, COUNT(st.StudentId) AS StudentCount
	FROM Teachers AS t
		JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
	GROUP BY t.FirstName, t.LastName
ORDER BY StudentCount DESC, t.FirstName, t.LastName

--Task 12
SELECT TOP(10) s.FirstName, s.LastName, CAST(AVG(se.Grade) AS DECIMAL(15,2)) AS Grade
	FROM StudentsExams AS se
		JOIN Students AS s ON se.StudentId = s.Id
	GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName

--Task 13
SELECT 
		c.FirstName, c.LastName, c.Grade
	FROM 
			(
				SELECT 
						s.FirstName AS FirstName,
						s.LastName AS LastName,
						sub.Name,
						ss.Grade AS Grade,
						DENSE_RANK() OVER (PARTITION BY s.FirstName, s.LastName
						ORDER BY ss.Grade DESC) AS [Rank] 
					FROM Students AS s
						 JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
						 JOIN Subjects AS sub ON ss.SubjectId = sub.Id	
			) AS c
		WHERE c.[Rank] = 2
ORDER BY c.FirstName, c.LastName

--Task 14
SELECT (CASE
			WHEN s.MiddleName IS NULL
				THEN s.FirstName + ' ' + s.LastName
			ELSE s.FirstName + ' ' + s.MiddleName + ' ' + s.LastName
		END) AS FullName
	FROM StudentsSubjects AS ss
		FULL JOIN Students AS s ON ss.StudentId = s.Id
	WHERE ss.SubjectId IS NULL
ORDER BY FullName

--Task 15


--Task 16
SELECT x.Name, x.Grade
	FROM 
		(
			SELECT	s.Id AS Id, s.Name AS Name, AVG(ss.Grade) AS Grade
				FROM Subjects AS s
					JOIN StudentsSubjects AS ss ON ss.SubjectId = s.Id
					JOIN Students AS st ON ss.StudentId = st.Id
				GROUP BY s.Id, s.Name
		) AS x
ORDER BY x.Id

--Task 17
SELECT 
		(CASE	
			WHEN MONTH(e.Date) BETWEEN 1 AND 3
				THEN 'Q1'
			WHEN MONTH(e.Date) BETWEEN 4 AND 6
				THEN 'Q2'
			WHEN MONTH(e.Date) BETWEEN 7 AND 9
				THEN 'Q3'
			WHEN MONTH(e.Date) BETWEEN 10 AND 12
				THEN 'Q4'
			ELSE 'TBA'
		END) AS [Quarter],
		s.[Name] AS SubjectName,
		COUNT(se.StudentId) AS Studentcount
	FROM Exams AS e
		JOIN StudentsExams AS se ON se.ExamId = e.Id
		JOIN Subjects AS s ON e.SubjectId = s.Id
		WHERE se.Grade >= 4.00
	GROUP BY 
				CASE	
					WHEN MONTH(e.Date) BETWEEN 1 AND 3
						THEN 'Q1'
					WHEN MONTH(e.Date) BETWEEN 4 AND 6
						THEN 'Q2'
					WHEN MONTH(e.Date) BETWEEN 7 AND 9
						THEN 'Q3'
					WHEN MONTH(e.Date) BETWEEN 10 AND 12
						THEN 'Q4'
					ELSE 'TBA'
				END,
				s.[Name]
ORDER BY [Quarter]

--Task 18
CREATE OR ALTER FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS NVARCHAR(MAX)
BEGIN
	
	DECLARE @student INT = (SELECT Id FROM Students WHERE Id = @studentId)

		IF (@student IS NULL)
		BEGIN
			RETURN 'The student with provided id does not exist in the school!'
		END

		IF(@grade > 6.00)
		BEGIN
			RETURN 'Grade cannot be above 6.00!'
		END

	DECLARE @count INT = 
						(
							SELECT COUNT(StudentId)
								FROM StudentsExams
									WHERE StudentId = @studentId AND Grade BETWEEN @grade AND @grade + 0.50 
						)
	DECLARE @firstName NVARCHAR(MAX) = (SELECT FirstName FROM Students WHERE Id = @studentId)

	RETURN 'You have to update ' + convert(nvarchar(255), @count) + ' grades for the student ' + @firstName
END

--Task 19
CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @student INT = (SELECT Id FROM Students WHERE Id = @StudentId)

	IF(@student IS NULL)
		BEGIN
			RAISERROR ('This school has no student with the provided id!', 16,1)
			RETURN
		END

	DELETE FROM StudentsExams
		WHERE StudentId = @StudentId

	DELETE FROM StudentsTeachers
		WHERE StudentId = @StudentId
	
	DELETE FROM StudentsSubjects
		WHERE StudentId = @StudentId
	
	DELETE FROM Students
		WHERE Id = @student
END

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

--Task 20
CREATE TABLE ExcludedStudents
	(
		StudentId INT, 
		StudentName NVARCHAR(MAX)
	);

CREATE TRIGGER tr_Exclude_Student ON Students FOR DELETE
AS
INSERT INTO ExcludedStudents (StudentId,StudentName)
	SELECT d.Id, d.FirstName + ' ' + d.LastName  FROM deleted AS d

