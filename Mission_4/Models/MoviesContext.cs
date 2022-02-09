using System;
using Microsoft.EntityFrameworkCore;

namespace Mission_4.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<Movies_Form> forms { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
                    new Category { CategoryID = 2, CategoryName = "Comedy" },
                    new Category { CategoryID = 3, CategoryName = "Drama" },
                    new Category { CategoryID = 4, CategoryName = "Family" },
                    new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                    new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                    new Category { CategoryID = 7, CategoryName = "Television" },
                    new Category { CategoryID = 8, CategoryName = "VHS" }
                );

            mb.Entity<Movies_Form>().HasData
            (
                new Movies_Form
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "Spider-Man: No Way Home",
                    Year = 2021,
                    Director = "Jon Favreau",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = "No",
                    Notes = "One of the all time greats"
                },
                new Movies_Form
                {
                    MovieID = 2,
                    CategoryID = 1,
                    Title = "Avengers: End Game",
                    Year = 2019,
                    Director = "Thor",
                    Rating = "PG-13",
                    Edited = false,
                    Lent = "No",
                    Notes = "Oh boy, what a classic"
                }
            );
        }

    }
}