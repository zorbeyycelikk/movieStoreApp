using Vk.Data.Context;

namespace Vk.UnitTest.TestSetup;

public static class Genre
{
    public static void AddGenres(this VkDbContext dbContext)
    {
        dbContext.AddRange(
    new Data.Domain.Genre
    {
        Id = 1,
        GenreNumber = 1,
        GenreName = "Action",
        InsertUserId = 301,
        InsertDate = DateTime.Now,
        UpdateUserId = 302,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = true
    },
    new Data.Domain.Genre
    {
        Id = 2,
        GenreNumber = 2,
        GenreName = "Drama",
        InsertUserId = 303,
        InsertDate = DateTime.Now.AddDays(-10),
        UpdateUserId = 304,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.Genre
    {
        Id = 3,
        GenreNumber = 3,
        GenreName = "Comedy",
        InsertUserId = 305,
        InsertDate = DateTime.Now.AddDays(-15),
        UpdateUserId = 306,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.Genre
    {
        Id = 4,
        GenreNumber = 4,
        GenreName = "Sci-Fi",
        InsertUserId = 307,
        InsertDate = DateTime.Now.AddDays(-20),
        UpdateUserId = 308,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = false
    },
    new Data.Domain.Genre
    {
        Id = 5,
        GenreNumber = 5,
        GenreName = "Thriller",
        InsertUserId = 309,
        InsertDate = DateTime.Now.AddDays(-25),
        UpdateUserId = 310,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = true
    },
    new Data.Domain.Genre
    {
        Id = 6,
        GenreNumber = 6,
        GenreName = "Romance",
        InsertUserId = 311,
        InsertDate = DateTime.Now.AddDays(-30),
        UpdateUserId = 312,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = false
    },
    new Data.Domain.Genre
    {
        Id = 7,
        GenreNumber = 7,
        GenreName = "Horror",
        InsertUserId = 313,
        InsertDate = DateTime.Now.AddDays(-35),
        UpdateUserId = 314,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.Genre
    {
        Id = 8,
        GenreNumber = 8,
        GenreName = "Mystery",
        InsertUserId = 315,
        InsertDate = DateTime.Now.AddDays(-40),
        UpdateUserId = 316,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.Genre
    {
        Id = 9,
        GenreNumber = 9,
        GenreName = "Fantasy",
        InsertUserId = 317,
        InsertDate = DateTime.Now.AddDays(-45),
        UpdateUserId = 318,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = true
    },
    new Data.Domain.Genre
    {
        Id = 10,
        GenreNumber = 10,
        GenreName = "Adventure",
        InsertUserId = 319,
        InsertDate = DateTime.Now.AddDays(-50),
        UpdateUserId = 320,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = false
    }
);
    }
    
}