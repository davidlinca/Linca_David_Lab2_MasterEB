using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Linca_David_Lab2_MasterEB.Models;

namespace Linca_David_Lab2_MasterEB.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Linca_David_Lab2_MasterEBContext(
                serviceProvider.GetRequiredService
                <DbContextOptions<Linca_David_Lab2_MasterEBContext>>()))
            {
                if (context.Book.Any())
                {
                    return;
                }

                var genres = new Genre[]
                {
                   new Genre { Name = "Roman" },
                   new Genre { Name = "Nuvela" },
                   new Genre { Name = "Poezie" }
                };
                context.Genre.AddRange(genres);
                context.SaveChanges();

                // Adaugă Autorii și Salvează-i pentru a obține ID-urile (necesare pentru Books)
                var authors = new Author[]
                {
                    new Author { FirstName = "Mihail", LastName = "Sadoveanu" },
                    new Author { FirstName = "George", LastName = "Calinescu" },
                    new Author { FirstName = "Mircea", LastName = "Eliade" }
                };
                context.Author.AddRange(authors);
                context.SaveChanges();

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Baltagul",
                        AuthorID = authors.Single(a => a.LastName == "Sadoveanu").ID,
                        Price = Decimal.Parse("22"),
                        GenreID = genres.Single(g => g.Name == "Roman").ID
                    },
                    new Book
                    {
                        Title = "Enigma Otiliei",
                        AuthorID = authors.Single(a => a.LastName == "Calinescu").ID,
                        Price = Decimal.Parse("18"),
                        GenreID = genres.Single(g => g.Name == "Roman").ID
                    },
                    new Book
                    {
                        Title = "Maytrei",
                        AuthorID = authors.Single(a => a.LastName == "Eliade").ID,
                        Price = Decimal.Parse("27"),
                        GenreID = genres.Single(g => g.Name == "Nuvela").ID
                    }
                );

                context.Customer.AddRange(
                    new Customer
                    {
                        Name = "Popescu Marcela",
                        Adress = "Str. Plopilor, nr. 24",
                        BirthDate = DateTime.Parse("1979-09-01")
                    },
                    new Customer
                    {
                        Name = "Mihailescu Cornel",
                        Adress = "Str. Bucuresti, nr.45, ap. 2",
                        BirthDate = DateTime.Parse("1969-07-08")
                    }
                );

                context.SaveChanges();
            }
        }
    }
}