using Vk.Data.Context;
using Vk.Data.Domain;

namespace Vk.UnitTest.TestSetup;

public static class Customer
{
    public static void AddCustomers(this VkDbContext dbContext)
    {
        dbContext.AddRange(new Data.Domain.Customer
    {
        Id = 1,
        CustomerNumber = 1,
        CustomerFirstName = "John",
        CustomerLastName = "Doe",
        InsertUserId = 101,
        InsertDate = DateTime.Now.AddDays(-5),
        UpdateUserId = 102,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = true
    },
    new Data.Domain.Customer
    {
        Id = 2,
        CustomerNumber = 2,
        CustomerFirstName = "Jane",
        CustomerLastName = "Smith",
        InsertUserId = 103,
        InsertDate = DateTime.Now.AddDays(-10),
        UpdateUserId = 104,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.Customer
    {
        Id = 3,
        CustomerNumber = 3,
        CustomerFirstName = "Bob",
        CustomerLastName = "Johnson",
        InsertUserId = 105,
        InsertDate = DateTime.Now.AddDays(-15),
        UpdateUserId = 106,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.Customer
    {
        Id = 4,
        CustomerNumber = 4,
        CustomerFirstName = "Emily",
        CustomerLastName = "Williams",
        InsertUserId = 107,
        InsertDate = DateTime.Now.AddDays(-20),
        UpdateUserId = 108,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = false
    },
    new Data.Domain.Customer
    {
        Id = 5,
        CustomerNumber = 5,
        CustomerFirstName = "Alex",
        CustomerLastName = "Brown",
        InsertUserId = 109,
        InsertDate = DateTime.Now.AddDays(-25),
        UpdateUserId = 110,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = true
    },
    new Data.Domain.Customer
    {
        Id = 6,
        CustomerNumber = 6,
        CustomerFirstName = "Sophia",
        CustomerLastName = "Miller",
        InsertUserId = 111,
        InsertDate = DateTime.Now.AddDays(-30),
        UpdateUserId = 112,
        UpdateDate = DateTime.Now.AddHours(-3),
        IsActive = false
    },
    new Data.Domain.Customer
    {
        Id = 7,
        CustomerNumber = 7,
        CustomerFirstName = "Jack",
        CustomerLastName = "Anderson",
        InsertUserId = 113,
        InsertDate = DateTime.Now.AddDays(-35),
        UpdateUserId = 114,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = true
    },
    new Data.Domain.Customer
    {
        Id = 8,
        CustomerNumber = 8,
        CustomerFirstName = "Ella",
        CustomerLastName = "Moore",
        InsertUserId = 115,
        InsertDate = DateTime.Now.AddDays(-40),
        UpdateUserId = 116,
        UpdateDate = DateTime.Now.AddHours(-1),
        IsActive = false
    },
    new Data.Domain.Customer
    {
        Id = 9,
        CustomerNumber = 9,
        CustomerFirstName = "Liam",
        CustomerLastName = "Davis",
        InsertUserId = 117,
        InsertDate = DateTime.Now.AddDays(-45),
        UpdateUserId = 118,
        UpdateDate = DateTime.Now.AddHours(-4),
        IsActive = true
    },
    new Data.Domain.Customer
    {
        Id = 10,
        CustomerNumber = 10,
        CustomerFirstName = "Ava",
        CustomerLastName = "Garcia",
        InsertUserId = 119,
        InsertDate = DateTime.Now.AddDays(-50),
        UpdateUserId = 120,
        UpdateDate = DateTime.Now.AddHours(-2),
        IsActive = false
    }
        );
    }
}