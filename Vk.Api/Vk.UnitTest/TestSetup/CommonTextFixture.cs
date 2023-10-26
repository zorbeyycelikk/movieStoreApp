using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Data.Context;
using Vk.Data.Uow;
using Vk.Operation.Mapper;

namespace Vk.UnitTest.TestSetup;

public class CommonTextFixture
{
    public VkDbContext dbContext { get; set; }
    
    public IMapper Mapper { get; set; }
    
    public IMediator mediator{ get; set; }


    public CommonTextFixture()
    {
        var options = new DbContextOptionsBuilder<VkDbContext>().UseInMemoryDatabase(databaseName: "movieStore").Options;
        dbContext = new VkDbContext(options);
        dbContext.Database.EnsureCreated(); // database'in yaratıldığından emin oluyor
        
        // Veri tabanını taklit ettik ve örnek datalarla beraber oluşturup dbyi ayağa kaldırdık.
        dbContext.AddCustomers();
        dbContext.AddActors();
        dbContext.AddDirectors();
        dbContext.AddGenres();
        
        dbContext.SaveChanges();

        // Mapper Eklendi
        Mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MapperConfig>();
        }).CreateMapper();
        
        // MediatR
    }

}