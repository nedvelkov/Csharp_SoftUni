namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
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

        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";

        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var movieDtos = JsonConvert
                .DeserializeObject<IEnumerable<MovieImportDto>>(jsonString);

            var movies = new List<Movie>();

            foreach (var dto in movieDtos)
            {
                if (IsValid(dto) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var titles = movies.Select(x => x.Title).ToList();
                if (titles.Contains(dto.Title))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var duration = TimeSpan.ParseExact(dto.Duration, "c",
                    CultureInfo.InvariantCulture);
                var genre = Enum.Parse<Genre>(dto.Genre);

                var movie = new Movie
                {
                    Title = dto.Title,
                    Genre = genre,
                    Duration = duration,
                    Rating = dto.Rating,
                    Director = dto.Director

                };
                movies.Add(movie);
                sb.AppendLine(String.Format(
                        SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("f2")));

            }
            context.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

            //  throw new NotImplementedException();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var moviesIdInDatabase = context.Movies.Select(x => x.Id).ToList();

            var projections = new List<Projection>();

            var projectionDtos = XmlConverter.Deserializer<ProjectionInputDto>(xmlString, "Projections");


            foreach (var dto in projectionDtos)
            {
                if (moviesIdInDatabase.Contains(dto.MovieId) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime dateTime;
                   var isValidDate= DateTime.TryParseExact(dto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture,DateTimeStyles.None,out dateTime);
                if (isValidDate==false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = dto.MovieId,
                    DateTime = dateTime
                };

                projections.Add(projection);

                var movieTitle = context.Movies.FirstOrDefault(x => x.Id == dto.MovieId).Title;

                var massage = String.Format(SuccessfulImportProjection, movieTitle, dateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
                sb.AppendLine(massage);

            }

            context.AddRange(projections);
            context.SaveChanges();


            return sb.ToString().TrimEnd();

            // throw new NotImplementedException();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var projectionsIdInDatabase = context.Projections.Select(x => x.Id).ToList();

            var customers = new List<Customer>();

            var customerDtos = XmlConverter.Deserializer<CustomerInputDto>(xmlString, "Customers");

            foreach (var dto in customerDtos)
            {
                if (IsValid(dto) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Balance = dto.Balance
                };

                foreach (var currentTiket in dto.Tickets)
                {
                    if(IsValid(currentTiket)==false 
                           || projectionsIdInDatabase.Contains(currentTiket.ProjectionId) == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var tiket = new Ticket
                    {
                        ProjectionId = currentTiket.ProjectionId,
                        Price = currentTiket.Price,
                    };

                    customer.Tickets.Add(tiket);

                }

                customers.Add(customer);

                sb.AppendLine(String.Format
                    (SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));

            }

            context.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}