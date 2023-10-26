using Vk.Data.Context;

namespace Vk.UnitTest.TestSetup;

public static class Actor
{
    public static void AddActors(this VkDbContext dbContext)
    {
        dbContext.AddRange(
    new Data.Domain.Actor
    {
        ActorNumber = 1,
        ActorFirstName = "John",
        ActorLastName = "Doe",
        InsertUserId = 101,
        InsertDate = DateTime.Now,
        UpdateUserId = 102,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = true
    },
    new Data.Domain.Actor
    {
        ActorNumber = 2,
        ActorFirstName = "Jane",
        ActorLastName = "Smith",
        InsertUserId = 103,
        InsertDate = DateTime.Now.AddDays(-10),
        UpdateUserId = 104,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.Actor
    {
        ActorNumber = 3,
        ActorFirstName = "Bob",
        ActorLastName = "Johnson",
        InsertUserId = 105,
        InsertDate = DateTime.Now.AddDays(-15),
        UpdateUserId = 106,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.Actor
    {
        ActorNumber = 4,
        ActorFirstName = "Emily",
        ActorLastName = "Williams",
        InsertUserId = 107,
        InsertDate = DateTime.Now.AddDays(-20),
        UpdateUserId = 108,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = false
    },
    new Data.Domain.Actor
    {
        ActorNumber = 5,
        ActorFirstName = "Alex",
        ActorLastName = "Brown",
        InsertUserId = 109,
        InsertDate = DateTime.Now.AddDays(-25),
        UpdateUserId = 110,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = true
    },
    new Data.Domain.Actor
    {
        ActorNumber = 6,
        ActorFirstName = "Sophia",
        ActorLastName = "Miller",
        InsertUserId = 111,
        InsertDate = DateTime.Now.AddDays(-30),
        UpdateUserId = 112,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = false
    },
    new Data.Domain.Actor
    {
        ActorNumber = 7,
        ActorFirstName = "Jack",
        ActorLastName = "Anderson",
        InsertUserId = 113,
        InsertDate = DateTime.Now.AddDays(-35),
        UpdateUserId = 114,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.Actor
    {
        ActorNumber = 8,
        ActorFirstName = "Ella",
        ActorLastName = "Moore",
        InsertUserId = 115,
        InsertDate = DateTime.Now.AddDays(-40),
        UpdateUserId = 116,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.Actor
    {
        ActorNumber = 9,
        ActorFirstName = "Liam",
        ActorLastName = "Davis",
        InsertUserId = 117,
        InsertDate = DateTime.Now.AddDays(-45),
        UpdateUserId = 118,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = true
    },
    new Data.Domain.Actor
    {
        ActorNumber = 10,
        ActorFirstName = "Ava",
        ActorLastName = "Garcia",
        InsertUserId = 119,
        InsertDate = DateTime.Now.AddDays(-50),
        UpdateUserId = 120,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = false
    }
);
    }
}