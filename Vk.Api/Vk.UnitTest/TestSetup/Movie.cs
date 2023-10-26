using Vk.Data.Context;

namespace Vk.UnitTest.TestSetup;

public static class Movie
{
    public static void AddMovies(this VkDbContext dbContext)
    {
        dbContext.AddRange(
    new Data.Domain.Movie
    {
        Id = 1,
        MovieNumber = 1,
        MovieName = "Inception",
        MovieYear = 2010,
        Price = 1299,
        GenreId = 1,
        DirectorId = 1,
        InsertUserId = 401,
        InsertDate = DateTime.Now,
        UpdateUserId = 402,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = true
    },
    new Data.Domain.Movie
    {
        Id = 2,
        MovieNumber = 2,
        MovieName = "Schindler's List",
        MovieYear = 1993,
        Price = 999,
        GenreId = 2,
        DirectorId = 2,
        InsertUserId = 403,
        InsertDate = DateTime.Now.AddDays(-10),
        UpdateUserId = 404,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.Movie
    {
        Id = 3,
        MovieNumber = 3,
        MovieName = "Pulp Fiction",
        MovieYear = 1994,
        Price = 1199,
        GenreId = 3,
        DirectorId = 3,
        InsertUserId = 405,
        InsertDate = DateTime.Now.AddDays(-15),
        UpdateUserId = 406,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.Movie
    {
        Id = 4,
        MovieNumber = 4,
        MovieName = "The Matrix",
        MovieYear = 1999,
        Price = 1099,
        GenreId = 4,
        DirectorId = 4,
        InsertUserId = 407,
        InsertDate = DateTime.Now.AddDays(-20),
        UpdateUserId = 408,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = false
    },
    new Data.Domain.Movie
    {
        Id = 5,
        MovieNumber = 5,
        MovieName = "The Silence of the Lambs",
        MovieYear = 1991,
        Price = 1499,
        GenreId = 5,
        DirectorId = 5,
        InsertUserId = 409,
        InsertDate = DateTime.Now.AddDays(-25),
        UpdateUserId = 410,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = true
    },
    new Data.Domain.Movie
    {
        Id = 6,
        MovieNumber = 6,
        MovieName = "La La Land",
        MovieYear = 2016,
        Price = 1399,
        GenreId = 6,
        DirectorId = 6,
        InsertUserId = 411,
        InsertDate = DateTime.Now.AddDays(-30),
        UpdateUserId = 412,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = false
    },
    new Data.Domain.Movie
    {
        Id = 7,
        MovieNumber = 7,
        MovieName = "Parasite",
        MovieYear = 2019,
        Price = 1599,
        GenreId = 7,
        DirectorId = 7,
        InsertUserId = 413,
        InsertDate = DateTime.Now.AddDays(-35),
        UpdateUserId = 414,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.Movie
    {
        Id = 8,
        MovieNumber = 8,
        MovieName = "Lost in Translation",
        MovieYear = 2003,
        Price = 899,
        GenreId = 8,
        DirectorId = 8,
        InsertUserId = 415,
        InsertDate = DateTime.Now.AddDays(-40),
        UpdateUserId = 416,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.Movie
    {
        Id = 9,
        MovieNumber = 9,
        MovieName = "The Grand Budapest Hotel",
        MovieYear = 2014,
        Price = 1699,
        GenreId = 9,
        DirectorId = 9,
        InsertUserId = 417,
        InsertDate = DateTime.Now.AddDays(-45),
        UpdateUserId = 418,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = true
    },
    new Data.Domain.Movie
    {
        Id = 10,
        MovieNumber = 10,
        MovieName = "Blade Runner",
        MovieYear = 1982,
        Price = 1299,
        GenreId = 10,
        DirectorId = 10,
        InsertUserId = 419,
        InsertDate = DateTime.Now.AddDays(-50),
        UpdateUserId = 420,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = false
    }
);
    }
}