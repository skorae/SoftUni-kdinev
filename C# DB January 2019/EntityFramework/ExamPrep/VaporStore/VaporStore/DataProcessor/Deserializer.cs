namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
        private const string Error = "Invalid Data";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var gamesDto = JsonConvert.DeserializeObject<GamesDto[]>(jsonString);
            var sb = new StringBuilder();

            var validGames = new List<Game>();

            foreach (var dto in gamesDto)
            {
                var isValid = IsValid(dto) && dto.Tags.All(x => IsValid(x));

                if (!isValid)
                {
                    sb.AppendLine(Error);
                    continue;
                }

                var developer = GetDeveloper(context, dto.Developer);
                var genre = GetGenre(context, dto.Genre);

                var game = new Game()
                {
                    Name = dto.Name,
                    ReleaseDate = DateTime.ParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Price = dto.Price,
                    Developer = developer,
                    Genre = genre
                };

                foreach (var t in dto.Tags)
                {
                    var tag = GetTag(context, t);

                    var gameTag = new GameTag()
                    {
                        Game = game,
                        Tag = tag
                    };

                    game.GameTags.Add(gameTag);
                }

                validGames.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(validGames);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
		}

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var usersDto = JsonConvert.DeserializeObject<UsersDto[]>(jsonString);

            var sb = new StringBuilder();
            var validUsers = new List<User>();

            foreach (var dto in usersDto)
            {
                var isValid = IsValid(dto) &&
                    dto.Cards.All(x => IsValid(x));

                var cardType = dto.Cards.All(x => Enum.TryParse(x.Type, out CardType type));
                
                if (!isValid || !cardType)
                {
                    sb.AppendLine(Error);
                    continue;
                }


                var user = new User()
                {
                    FullName = dto.FullName,
                    Username = dto.Username,
                    Age = dto.Age,
                    Email = dto.Email,
                    Cards = dto.Cards.Select(x => new Card()
                    {
                        Type = Enum.Parse<CardType>(x.Type),
                        Number = x.Number,
                        Cvc = x.CVC
                    })
                    .ToHashSet()
                };

                validUsers.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(PurchaseDto[]), new XmlRootAttribute("Purchases"));

            var purchasesDto = (PurchaseDto[])serializer.Deserialize(new StringReader(xmlString));
            var validPurchases = new List<Purchase>();

            foreach (var dto in purchasesDto)
            {
                var isValid = IsValid(dto) &&
                    Enum.TryParse<PurchaseType>(dto.PurchaseType, out PurchaseType purchaseType);

                if (!isValid)
                {
                    sb.AppendLine(Error);
                    continue;
                }

                var game = GetGame(context, dto.GameTitle);
                var card = GetCard(context, dto.CardNumber);

                var purchase = new Purchase()
                {
                    Type = Enum.Parse<PurchaseType>(dto.PurchaseType),
                    ProductKey = dto.ProductKey,
                    Card = card,
                    Game = game
                };

                validPurchases.Add(purchase);
                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(validPurchases);
            context.SaveChanges();

            var result = sb.ToString().Trim();

            return result;
        }

        private static Card GetCard(VaporStoreDbContext context, string cardNumber)
        {
            return context.Cards.FirstOrDefault(x => x.Number == cardNumber);
        }

        private static Game GetGame(VaporStoreDbContext context, string gameTitle)
        {
            return context.Games.FirstOrDefault(x => x.Name == gameTitle);
        }

        private static Tag GetTag(VaporStoreDbContext context, string name)
        {
            var tag = context.Tags.FirstOrDefault(x => x.Name == name);

            if (tag != null)
            {
                return tag;
            }

            tag = new Tag()
            {
                Name = name
            };

            context.Tags.Add(tag);
            context.SaveChanges();

            return tag;
        }

        private static Genre GetGenre(VaporStoreDbContext context, string name)
        {
            var genre = context.Genres.FirstOrDefault(x => x.Name == name);

            if (genre != null)
            {
                return genre;
            }

            genre = new Genre()
            {
                Name = name
            };

            context.Genres.Add(genre);
            context.SaveChanges();

            return genre;
        }

        private static Developer GetDeveloper(VaporStoreDbContext context, string name)
        {
            var developer = context.Developers.FirstOrDefault(x => x.Name == name);

            if (developer != null)
            {
                return developer;
            }

            developer = new Developer()
            {
                Name = name
            };

            context.Developers.Add(developer);
            context.SaveChanges();

            return developer;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}