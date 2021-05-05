namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context
                .Movies
                .ToArray()
                .OrderByDescending(x=>x.Rating)
                .ThenByDescending(x=>x.Projections.Sum(c=>c.Tickets.Sum(t=>t.Price)))
                .Where(x => x.Rating >= rating && x.Projections.Any(x => x.Tickets.Count > 0))
                .Select(x => new MovieOutputDto
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("f2"),
                    TotalIncomes = x.Projections.Sum(c => c.Tickets.Sum(t => t.Price)).ToString("f2"),
                    Customers = x.Projections.SelectMany(t => t.Tickets.Select(c => new CustomerOutputDto
                    {
                        FirstName = c.Customer.FirstName,
                        LastName = c.Customer.LastName,
                        Balance = c.Customer.Balance.ToString("f2"),
                    })).ToArray()
                })
                .Take(10)
                .ToList();

         //   movies = movies.OrderByDescending(r => r.Rating).ThenByDescending(i => i.TotalIncomes).Take(10).ToList();

            for (int i = 0; i < movies.Count; i++)
            {
                var current = movies[i];
                current.Customers = current.Customers
                    .OrderByDescending(x => x.Balance).ThenBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            }

            string jsonString = JsonConvert.SerializeObject(movies,Formatting.Indented);

            return jsonString;

            throw new NotImplementedException();
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
                .Customers
                .Where(a => a.Age >= age)
                .ToArray()
                .OrderByDescending(x => x.Tickets.Sum(t => t.Price))
                .Select(x => new CustomerExportDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(t => t.Price).ToString("f2"),
                    SpentTime =TimeSpan.FromSeconds( x.Tickets.Sum(p => p.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")
                })
               .Take(10)
               .ToArray();

            var xmlString = XmlConverter.Serialize(customers, "Customers");

            return xmlString;

            // throw new NotImplementedException();
        }
    }
}