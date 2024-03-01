using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPageMovie.Data;

namespace RazorPageMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMovieContextDb(serviceProvider.GetRequiredService<DbContextOptions<RazorPageMovieContextDb>>()))
            {
                if (!context.Movie.Any())
                {
                    context.AddRange(
                        new Movie
                        {
                            Title = "The Shawshank Redemption",
                            ReleaseDate = new DateTime(1994, 10, 14),
                            Genre = "Drama",
                            Price = 8.99M,
                            Rating = "R"
                        },
                        new Movie
                        {
                            Title = "The Godfather",
                            ReleaseDate = new DateTime(1972, 3, 24),
                            Genre = "Crime, Drama",
                            Price = 10.99M,
                            Rating = "R"
                        },
                        new Movie
                        {
                            Title = "The Dark Knight",
                            ReleaseDate = new DateTime(2008, 7, 18),
                            Genre = "Action, Crime, Drama",
                            Price = 9.99M,
                            Rating = "R"
                        },
                        new Movie
                        {
                            Title = "Schindler's List",
                            ReleaseDate = new DateTime(1993, 12, 15),
                            Genre = "Biography, Drama, History",
                            Price = 8.49M,
                            Rating = "R"
                        },
                        new Movie
                        {
                            Title = "Pulp Fiction",
                            ReleaseDate = new DateTime(1994, 10, 14),
                            Genre = "Crime, Drama",
                            Price = 7.99M,
                            Rating = "R"
                        },
                        new Movie
                        {
                            Title = "The Lord of the Rings: The Return of the King",
                            ReleaseDate = new DateTime(2003, 12, 17),
                            Genre = "Action, Adventure, Drama",
                            Price = 11.49M,
                            Rating = "R"
                        },
                        new Movie
                        {
                            Title = "Fight Club",
                            ReleaseDate = new DateTime(1999, 10, 15),
                            Genre = "Drama",
                            Price = 7.99M,
                            Rating = "R"
                        },
                        new Movie
                        {
                            Title = "Forrest Gump",
                            ReleaseDate = new DateTime(1994, 7, 6),
                            Genre = "Drama, Romance",
                            Price = 7.99M,
                            Rating = "R"
                        },
                        new Movie
                        {
                            Title = "Inception",
                            ReleaseDate = new DateTime(2010, 7, 16),
                            Genre = "Action, Adventure, Sci-Fi",
                            Price = 10.99M,
                            Rating = "R"
                        },
                        new Movie
                        {
                            Title = "The Matrix",
                            ReleaseDate = new DateTime(1999, 3, 31),
                            Genre = "Action, Sci-Fi",
                            Price = 8.49M,
                            Rating = "R"
                        }
                    );

                    context.SaveChanges(); // Guardar los cambios en la base de datos
                }
            }
        }
    }
}
