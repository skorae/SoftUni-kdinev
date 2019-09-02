namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);

            var validMovies = context.Movies.ToList();
            var sb = new StringBuilder();

            foreach (var dto in moviesDto)
            {
                var isValid = IsValid(dto) &&
                     Enum.TryParse<Genre>(dto.Genre, out Genre genre);

                if (!isValid || validMovies.Any(x => x.Title == dto.Title)) 
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie()
                {
                    Title = dto.Title,
                    Genre = Enum.Parse<Genre>(dto.Genre),
                    Duration = TimeSpan.Parse(dto.Duration),
                    Rating = dto.Rating,
                    Director = dto.Director
                };

                validMovies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre.ToString(), movie.Rating.ToString("F")));
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            var result = sb.ToString();

            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            var validHalls = new List<Hall>();
            var sb = new StringBuilder();

            foreach (var dto in hallsDto)
            {
                var isValid = IsValid(dto);

                if (!isValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall()
                {
                    Name = dto.Name,
                    Is3D = dto.Is3D,
                    Is4Dx = dto.Is4Dx
                };

                for (int i = 0; i < dto.Seats; i++)
                {
                    hall.Seats.Add(new Seat()
                    {
                        Hall = hall
                    });
                }

                var hallType = GetHallType(hall);


                validHalls.Add(hall);
                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, hallType, hall.Seats.Count));
            }

            context.Halls.AddRange(validHalls);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var movies = context.Movies.ToList();
            var halls = context.Halls.ToList();
            
            var seializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
            var sb = new StringBuilder();

            var projectionsDto = (ImportProjectionDto[])seializer.Deserialize(new StringReader(xmlString));
            var validProjections = new List<Projection>();

            foreach (var dto in projectionsDto)
            {
                var isValid = IsValid(dto) &&
                    movies.Any(x => x.Id == dto.MovieId) &&
                    halls.Any(x => x.Id == dto.HallId);

                if (!isValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                var projection = new Projection()
                {
                    Hall = halls.FirstOrDefault(x => x.Id == dto.HallId),
                    Movie = movies.FirstOrDefault(x => x.Id == dto.MovieId),
                    DateTime = DateTime.ParseExact(dto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                validProjections.Add(projection);
                sb.AppendLine(string.Format(SuccessfulImportProjection, 
                    projection.Movie.Title, 
                    projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }

            context.Projections.AddRange(validProjections);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var projections = context.Projections.ToList();

            var seializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            var sb = new StringBuilder();

            var customerDto = (ImportCustomerDto[])seializer.Deserialize(new StringReader(xmlString));
            var validCustomers = new List<Customer>();

            foreach (var dto in customerDto)
            {
                var isValid = IsValid(dto) &&
                    dto.Tickets.All(x => IsValid(x)) &&
                    dto.Tickets.All(x => projections.Any(y => y.Id == x.ProjectionId));

                if (!isValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Balance = dto.Balance,
                    Tickets = dto.Tickets.Select(x => new Ticket()
                    {
                        ProjectionId = x.ProjectionId,
                        Price = x.Price
                    })
                    .ToHashSet()
                };

                validCustomers.Add(customer);
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }
        
        private static string GetHallType(Hall hall)
        {
            var type = string.Empty;

            if (hall.Is3D && hall.Is4Dx)
            {
               return "4Dx/3D";
            }

            if (hall.Is3D)
            {
                return "3D";
            }

            if (hall.Is4Dx)
            {
                return "4Dx";
            }

            if (!hall.Is4Dx && !hall.Is4Dx)
            {
                return "Normal";
            }

            return type;
        }

        private static bool IsValid(object obj)
        {
            var validationsContext = new ValidationContext(obj);
            var validationsResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationsContext, validationsResults, true);

            return isValid;
        }
    }
}