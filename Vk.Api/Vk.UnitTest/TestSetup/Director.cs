using Vk.Data.Context;

namespace Vk.UnitTest.TestSetup;

public static class Director
{
    public static void AddDirectors(this VkDbContext dbContext)
    {
        dbContext.AddRange(
    new Data.Domain.Director
    {
        Id = 1,
        DirectorNumber = 1,
        DirectorFirstName = "Christopher",
        DirectorLastName = "Nolan",
        InsertUserId = 201,
        InsertDate = DateTime.Now,
        UpdateUserId = 202,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = true
    },
    new Data.Domain.Director
    {
        Id = 2,
        DirectorNumber = 2,
        DirectorFirstName = "Steven",
        DirectorLastName = "Spielberg",
        InsertUserId = 203,
        InsertDate = DateTime.Now.AddDays(-10),
        UpdateUserId = 204,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.Director
    {
        Id = 3,
        DirectorNumber = 3,
        DirectorFirstName = "Quentin",
        DirectorLastName = "Tarantino",
        InsertUserId = 205,
        InsertDate = DateTime.Now.AddDays(-15),
        UpdateUserId = 206,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.Director
    {
        Id = 4,
        DirectorNumber = 4,
        DirectorFirstName = "Greta",
        DirectorLastName = "Gerwig",
        InsertUserId = 207,
        InsertDate = DateTime.Now.AddDays(-20),
        UpdateUserId = 208,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = false
    },
    new Data.Domain.Director
    {
        Id = 5,
        DirectorNumber = 5,
        DirectorFirstName = "Martin",
        DirectorLastName = "Scorsese",
        InsertUserId = 209,
        InsertDate = DateTime.Now.AddDays(-25),
        UpdateUserId = 210,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = true
    },
    new Data.Domain.Director
    {
        Id = 6,
        DirectorNumber = 6,
        DirectorFirstName = "Ava",
        DirectorLastName = "DuVernay",
        InsertUserId = 211,
        InsertDate = DateTime.Now.AddDays(-30),
        UpdateUserId = 212,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = false
    },
    new Data.Domain.Director
    {
        Id = 7,
        DirectorNumber = 7,
        DirectorFirstName = "Bong",
        DirectorLastName = "Joon-ho",
        InsertUserId = 213,
        InsertDate = DateTime.Now.AddDays(-35),
        UpdateUserId = 214,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.Director
    {
        Id = 8,
        DirectorNumber = 8,
        DirectorFirstName = "Sofia",
        DirectorLastName = "Coppola",
        InsertUserId = 215,
        InsertDate = DateTime.Now.AddDays(-40),
        UpdateUserId = 216,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.Director
    {
        Id = 9,
        DirectorNumber = 9,
        DirectorFirstName = "Wes",
        DirectorLastName = "Anderson",
        InsertUserId = 217,
        InsertDate = DateTime.Now.AddDays(-45),
        UpdateUserId = 218,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = true
    },
    new Data.Domain.Director
    {
        Id = 10,
        DirectorNumber = 10,
        DirectorFirstName = "Ridley",
        DirectorLastName = "Scott",
        InsertUserId = 219,
        InsertDate = DateTime.Now.AddDays(-50),
        UpdateUserId = 220,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = false
    }
);
    }
}