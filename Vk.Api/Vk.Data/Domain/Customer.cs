using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vk.Base.Model;

namespace Vk.Data.Domain;

[Table("Customer", Schema = "dbo")]
public class Customer : BaseModel
{
    public int    CustomerNumber { get; set; }     // Müsteri Unique Number(Sicil gibi)
    public string CustomerFirstName  { get; set; } // Musteri Adi
    public string CustomerLastName  { get; set; }  // Musteri Soy Adi
    
    public virtual List<UserFavoriteMovieGenres> UserFavoriteMovieGenresList { get; set; }
    public virtual List<Order> Orders { get; set; } // Musteri bir den çok siparişi olabilir.
}
class CustomerConfigruration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        
        builder.Property(x => x.CustomerNumber).IsRequired();
        builder.Property(x => x.CustomerFirstName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.CustomerLastName).IsRequired().HasMaxLength(50);
        
        builder.HasIndex(x => x.CustomerNumber);
          
        builder.HasMany(x => x.Orders) //Bir Customer'ın birden çok siparişi olabilir
            .WithOne(x => x.Customer) // Bir siparişin bir tane Customer'ı olabilir
            .HasPrincipalKey(c => c.CustomerNumber)
            .IsRequired(true);
        
        builder.HasMany(x => x.UserFavoriteMovieGenresList) //Bir Customer'ın birden çok siparişi olabilir
            .WithOne(x => x.Customer) // Bir siparişin bir tane Customer'ı olabilir
            .HasForeignKey(x => x.CustomerId)
            .IsRequired(true);
    }
}