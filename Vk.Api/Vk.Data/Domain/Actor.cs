using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vk.Base.Model;

namespace Vk.Data.Domain;

[Table("Actor", Schema = "dbo")]
public class Actor : BaseModel
{
    public int ActorNumber { get; set; }     // Oyuncu Unique Number(Sicil gibi)
    public string ActorFirstName  { get; set; } // Oyuncu Adi
    public string ActorLastName  { get; set; }  // Oyuncu Soy Adi
    
    public virtual List<Movie> Movies { get; set; } // Oyuncu bir den çok filmde oynayabilir.
}

class ActorConfigruration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        
        builder.Property(x => x.ActorNumber).IsRequired();
        builder.Property(x => x.ActorFirstName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.ActorLastName).IsRequired().HasMaxLength(50);
        
        builder.HasIndex(x => x.ActorNumber);
    }
}