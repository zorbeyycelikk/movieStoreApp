using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vk.Base.Model;

namespace Vk.Data.Domain;

[Table("Director", Schema = "dbo")]
public class Director : BaseModel
{
    public int DirectorNumber { get; set; }     // Yonetmen Unique Number(Sicil gibi)
    public string DirectorFirstName  { get; set; } // Yönetmen Adi
    public string DirectorLastName  { get; set; } // Yönetmen Soy Adi
    
    public virtual List<Movie> Movies { get; set; } // Yönetmen birden çok film yönetebilir.
}

class DirectorConfigruration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        
        builder.Property(x => x.DirectorNumber).IsRequired();
        builder.Property(x => x.DirectorFirstName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.DirectorLastName).IsRequired().HasMaxLength(50);
        
        builder.HasIndex(x => x.DirectorNumber);
    }
}