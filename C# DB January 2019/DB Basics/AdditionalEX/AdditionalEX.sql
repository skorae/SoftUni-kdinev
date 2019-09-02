--Task 1
USE Diablo

SELECT RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider],
		COUNT(*) AS [Number Of Users]
	FROM Users 
			WHERE LEN(Email) > 0
	GROUP BY RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))
	ORDER BY [Number Of Users] DESC,
				[Email Provider]

--Task 2
SELECT g.[Name] AS Game, gt.[Name] AS [Game Type] ,u.Username, us.Level,us.Cash, c.[Name]
	FROM Users AS u
		JOIN UsersGames AS us ON us.UserId = u.Id
		JOIN Games AS g ON us.GameId = g.Id
		JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
		JOIN Characters AS c ON us.CharacterId = c.Id
	ORDER BY us.Level DESC,
				u.Username,
				g.[Name]

--Task 3
SELECT u.Username, g.[Name], COUNT(*) AS [Items Count], SUM(i.Price) AS [Items Price]
	FROM Users AS u
		JOIN UsersGames AS ug ON ug.UserId = u.Id
		JOIN Games AS g ON ug.GameId = g.Id
		JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
		JOIN Items AS i ON ugi.ItemId = i.Id
	GROUP BY u.Username, g.[Name]
		HAVING  COUNT(*) >= 10
ORDER BY [Items Count] DESC,
			[Items Price] DESC,
			u.Username

--Task 4
