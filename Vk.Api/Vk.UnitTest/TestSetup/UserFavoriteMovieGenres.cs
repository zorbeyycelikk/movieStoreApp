using Vk.Data.Context;

namespace Vk.UnitTest.TestSetup;

public static  class UserFavoriteMovieGenres
{
    public static void AddUserFavoriteMovieGenres(this VkDbContext dbContext)
    {
        dbContext.AddRange(
    new Data.Domain.UserFavoriteMovieGenres
    {
        Id = 1,
        CustomerId = 1,
        FavoriteGenreId = 1,
        InsertUserId = 501,
        InsertDate = DateTime.Now,
        UpdateUserId = 502,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = true
    },
    new Data.Domain.UserFavoriteMovieGenres
    {
        Id = 2,
        CustomerId = 2,
        FavoriteGenreId = 2,
        InsertUserId = 503,
        InsertDate = DateTime.Now.AddDays(-10),
        UpdateUserId = 504,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.UserFavoriteMovieGenres
    {
        Id = 3,
        CustomerId = 3,
        FavoriteGenreId = 3,
        InsertUserId = 505,
        InsertDate = DateTime.Now.AddDays(-15),
        UpdateUserId = 506,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.UserFavoriteMovieGenres
    {
        Id = 4,
        CustomerId = 4,
        FavoriteGenreId = 4,
        InsertUserId = 507,
        InsertDate = DateTime.Now.AddDays(-20),
        UpdateUserId = 508,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = false
    },
    new Data.Domain.UserFavoriteMovieGenres
    {
        Id = 5,
        CustomerId = 5,
        FavoriteGenreId = 5,
        InsertUserId = 509,
        InsertDate = DateTime.Now.AddDays(-25),
        UpdateUserId = 510,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = true
    },
    new Data.Domain.UserFavoriteMovieGenres
    {
        Id = 6,
        CustomerId = 6,
        FavoriteGenreId = 6,
        InsertUserId = 511,
        InsertDate = DateTime.Now.AddDays(-30),
        UpdateUserId = 512,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = false
    },
    new Data.Domain.UserFavoriteMovieGenres
    {
        Id = 7,
        CustomerId = 7,
        FavoriteGenreId = 7,
        InsertUserId = 513,
        InsertDate = DateTime.Now.AddDays(-35),
        UpdateUserId = 514,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.UserFavoriteMovieGenres
    {
        Id = 8,
        CustomerId = 8,
        FavoriteGenreId = 8,
        InsertUserId = 515,
        InsertDate = DateTime.Now.AddDays(-40),
        UpdateUserId = 516,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.UserFavoriteMovieGenres
    {
        Id = 9,
        CustomerId = 9,
        FavoriteGenreId = 9,
        InsertUserId = 517,
        InsertDate = DateTime.Now.AddDays(-45),
        UpdateUserId = 518,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = true
    },
    new Data.Domain.UserFavoriteMovieGenres
    {
        Id = 10,
        CustomerId = 10,
        FavoriteGenreId = 10,
        InsertUserId = 519,
        InsertDate = DateTime.Now.AddDays(-50),
        UpdateUserId = 520,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = false
    }
);
    }
}