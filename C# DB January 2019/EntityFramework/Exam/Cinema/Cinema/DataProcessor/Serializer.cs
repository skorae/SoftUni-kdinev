namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context
                .Movies
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
                .Where(x => 
                    //x.Projections.Any() && 
                    x.Rating >= rating &&
                    x.Projections.Any(p => p.Tickets.Any())) 
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("F"),
                    TotalIncomes = x.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F"),
                    Customers = x.Projections
                        .Where(t => t.Tickets.Any())
                        .SelectMany(t => t.Tickets)
                        .Select(c => new
                        {
                            FirstName = c.Customer.FirstName,
                            LastName = c.Customer.LastName,
                            Balance = c.Customer.Balance.ToString("F")
                        })
                        .OrderByDescending(c => c.Balance)
                        .ThenBy(c => c.FirstName)
                        .ThenBy(c => c.LastName)
                        .ToArray()
                })
                .Take(10)
                .ToArray();

            var json = JsonConvert.SerializeObject(movies, Formatting.Indented);

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var sb = new StringBuilder();

            var customers = context
                .Customers
                .Where(x => x.Age >= age)
                .OrderByDescending(x => x.Tickets.Sum(t => t.Price))
                .Select(x => new ExportCustomerDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(t => t.Price).ToString("F"),
                    SpentTime = GetSpentTime(x.Tickets.Select(m => m.Projection.Movie.Duration).ToArray()).ToString(@"hh\:mm\:ss")
                })
                .Take(10)
                .ToArray();

            var serializar = new XmlSerializer(typeof(ExportCustomerDto[]), new XmlRootAttribute("Customers"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            serializar.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().Trim();
        }

        private static TimeSpan GetSpentTime(TimeSpan[] timeSpan)
        {
            var time = new TimeSpan();

            foreach (var t in timeSpan)
            {
                time = time.Add(t);
            }

            return time;
        }
    }
}