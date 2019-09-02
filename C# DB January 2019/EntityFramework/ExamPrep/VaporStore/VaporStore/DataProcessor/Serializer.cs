namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;
    using Formatting = Newtonsoft.Json.Formatting;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var games = context
                .Genres
                .Where(x => x.Games.Any(p => p.Purchases.Any()) && genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                        .Where(g => g.Purchases.Any())
                        .Select(g => new
                        {
                            Id = g.Id,
                            Title = g.Name,
                            Developer = g.Developer.Name,
                            Tags = string.Join(", ", g.GameTags.Select(t => t.Tag.Name)),
                            Players = g.Purchases.Count
                        })
                        .OrderByDescending(g => g.Players)
                        .ThenBy(g => g.Id)
                        .ToArray(),
                    TotalPlayers = x.Games.Sum(p => p.Purchases.Count)
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(games, Formatting.Indented);

            return json;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            var type = Enum.Parse<PurchaseType>(storeType);

            var users = context
                .Users
                .Select(u => new ExportUseDto
                {
                    UserName = u.Username,
                    Purchases = u.Cards
                        .SelectMany(x => x.Purchases)
                        .Where(x => x.Type == type)
                        .Select(x => new ExportPurchaseDto
                        {
                            CardNumber = x.Card.Number,
                            Cvc = x.Card.Cvc,
                            Date = x.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InstalledUICulture),
                            Game = new ExportGameDto
                            {
                                Title = x.Game.Name,
                                Genre = x.Game.Genre.Name,
                                Price = x.Game.Price
                            },
                        })
                        .OrderBy(x => x.Date)
                        .ToArray(),
                    TotalSpent = u.Cards
                        .SelectMany(x => x.Purchases)
                        .Where(x => x.Type == type)
                        .Sum(x => x.Game.Price)
                })
                .Where(h => h.Purchases.Any())
                .OrderByDescending(h => h.TotalSpent)
                .ThenBy(h => h.UserName)
                .ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ExportUseDto[]), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            serializer.Serialize(new StringWriter(sb), users, namespaces);

            var result = sb.ToString().Trim();

            return result;
		}
	}
}