using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vk.Base.Model;

namespace Vk.Data.Domain;

[Table("Genre", Schema = "dbo")]
public class Genre : BaseModel
{
    public int GenreNumber { get; set; }    // Tür Numarasi
    public string GenreName  { get; set; }  // Tür Adi
    
    public virtual List<Movie> Movies { get; set; } // Bir türde birden çok film olabilir
}

class GenreConfigruration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        
        builder.Property(x => x.GenreNumber).IsRequired();
        builder.Property(x => x.GenreName).IsRequired().HasMaxLength(50);
        
        builder.HasIndex(x => x.GenreNumber);
    }
}