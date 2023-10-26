using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vk.Base.Model;

namespace Vk.Data.Domain;

[Table("Order", Schema = "dbo")]
public class Order : BaseModel
{
        public string      PurschaseNumber { get; set; }     // Satın Alma Fiş No(unique)
        public string   PurchaserCustomer  { get; set; }  // Satın Alan Müşteri İsmi
        public string   PurchasedMovie     { get; set; }  // Satın Alınan Filmler
        public int      Price              { get; set; }  // Fiyat
        public DateTime PurchaseDate       { get; set; }  // Satin Alma Tarihi
        
        public int CustomerId { get; set; }             // Customer'dan referans alınacak
        public virtual Customer Customer { get; set; } // Bir Musteri bir den çok film satin alabilir.
}

class OrderConfigruration : IEntityTypeConfiguration<Order>
{
        public void Configure(EntityTypeBuilder<Order> builder)
        {
                builder.Property(x => x.InsertUserId).IsRequired();
                builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
                builder.Property(x => x.InsertDate).IsRequired();
                builder.Property(x => x.UpdateDate).IsRequired(false);
                builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        
                builder.Property(x => x.PurschaseNumber).IsRequired();
                builder.Property(x => x.PurchaserCustomer).IsRequired().HasMaxLength(50);
                builder.Property(x => x.PurchasedMovie).IsRequired();
                builder.Property(x => x.Price).IsRequired();
                builder.Property(x => x.PurchaseDate).IsRequired();
        
                builder.Property(x => x.CustomerId).IsRequired();
        
                builder.HasIndex(x => x.PurschaseNumber);
        }
}