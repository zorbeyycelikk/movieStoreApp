
using Microsoft.EntityFrameworkCore;
using Vk.Data.Domain;

namespace Vk.Data.Context;

public class VkDbContext : DbContext
{
    public VkDbContext(DbContextOptions<VkDbContext> options) : base(options)
    {

    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ActorConfigruration());
        modelBuilder.ApplyConfiguration(new CustomerConfigruration());
        modelBuilder.ApplyConfiguration(new DirectorConfigruration());
        modelBuilder.ApplyConfiguration(new GenreConfigruration());
        modelBuilder.ApplyConfiguration(new MovieConfigruration());
        modelBuilder.ApplyConfiguration(new OrderConfigruration());
        
        base.OnModelCreating(modelBuilder);
    }

}