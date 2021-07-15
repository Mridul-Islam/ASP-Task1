using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize (IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>())){
                    // LOOK for any movies
                    if(context.Movie.Any()){
                        return; // DB has been seeded
                    }
                    context.Movie.AddRange(
                        new Movie
                        {
                            Title = "When Harry meet Sally",
                            ReleaseDate = DateTime.Parse("1989-2-12"),
                            Genre = "Romantic Comedy",
                            price = 7.99M,
                            Rating = "R"
                        },
                        new Movie
                        {
                            Title = "Ghostbuster ",
                            ReleaseDate = DateTime.Parse("1984-3-13"),
                            Genre = "Comedy",
                            price = 8.99M,
                            Rating = "R"
                        },
                        new Movie
                        {
                            Title = "Ghostbusters 2",
                            ReleaseDate = DateTime.Parse("1986-2-23"),
                            Genre = "Comedy",
                            price = 9.99M,
                            Rating = "R"
                        },
                        new Movie{
                            Title = "Rio Bravo",
                            ReleaseDate = DateTime.Parse("1959-4-15"),
                            Genre = "Western",
                            price = 3.99M,
                            Rating = "R"
                        }
                    );
                    context.SaveChanges();
                }
        }
    } 
}