namespace BookShop
{
    using Data;
    using System;
    using Initializer;
    using System.Text;
    using BookShop.Models.Enums;
    using System.Linq;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using (BookShopContext context = new BookShopContext())
            {
                //string command = Console.ReadLine();
                //int n = int.Parse(Console.ReadLine());

                RemoveBooks(context);

                //Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder builder = new StringBuilder();

            var restriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(x => x.AgeRestriction == restriction)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            foreach (var book in books)
            {
                builder.AppendLine(book);
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder builder = new StringBuilder();

            var bookType = Enum.Parse<EditionType>("gold", true);

            var goldenBooks = context
                .Books
                .Where(x => x.EditionType == bookType && x.Copies < 5000)
                .Select(x => x.Title)
                .ToList();

            foreach (var book in goldenBooks)
            {
                builder.AppendLine(book);
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder builder = new StringBuilder();

            var books = context
                .Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            foreach (var b in books)
            {
                builder.AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder builder = new StringBuilder();

            var books = context
                .Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            foreach (var book in books)
            {
                builder.AppendLine(book);
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder builder = new StringBuilder();

            string[] ganre = input.ToLower().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            var books = context
                .Books

                .Where(x => x.BookCategories.Any(c => ganre.Contains(c.Category.Name.ToLower())))
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToList();

            foreach (var book in books)
            {
                builder.AppendLine(book);
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder builder = new StringBuilder();

            DateTime targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(x => x.ReleaseDate < targetDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToList();

            foreach (var book in books)
            {
                builder.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => x.FirstName + " " + x.LastName)
                .OrderBy(x => x)
                .ToList();

            string result = string.Join(Environment.NewLine, authors);

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            string result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder builder = new StringBuilder();

            var booksAndAuthors = context
                .Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    FullName = x.Author.FirstName + " " + x.Author.LastName,
                    x.Title
                })
                .ToList();

            foreach (var ba in booksAndAuthors)
            {
                builder.AppendLine($"{ba.Title} ({ba.FullName})");
            }

            return builder.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int count = context
                .Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return count;               
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder builder = new StringBuilder();

            var authors = context
                .Authors
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    Copies = x.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            foreach (var a in authors)
            {
                builder.AppendLine($"{a.FullName} - {a.Copies}");
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder builder = new StringBuilder();

            var profit = context
                .Categories
                .Select(x => new
                {
                    Category = x.Name,
                    Profit = x.CategoryBooks.Sum(c => c.Book.Copies * c.Book.Price)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Category)
                .ToList();

            foreach (var p in profit)
            {
                builder.AppendLine($"{p.Category} ${p.Profit}");
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder builder = new StringBuilder();

            var books = context
                .Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Books = x.CategoryBooks.Select(b => new
                    {
                        BookTitle = b.Book.Title,
                        ReleaseDate = b.Book.ReleaseDate
                    })
                    .OrderByDescending(r => r.ReleaseDate)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var title in books)
            {
                builder.AppendLine($"--{title.Name}");

                foreach (var book in title.Books)
                {
                    builder.AppendLine($"{book.BookTitle} ({book.ReleaseDate.Value.Year})");
                }
            }
            return builder.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(x => x.Copies < 4200)
                .ToList();

            int count = 0;

            foreach (var book in books)
            {
                context.Books.Remove(book);
                count++;
            }

            context.SaveChanges();
            
            return count;
        }
    }
}
