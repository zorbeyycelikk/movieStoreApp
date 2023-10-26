using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vk.Base.Model;

namespace Vk.Data.Domain;

[Table("UserFavoriteMovieGenres", Schema = "dbo")]
public class UserFavoriteMovieGenres : BaseModel
{
    public int CustomerId  { get; set; }    // Kullanici Id (Foreign From Customer)
    public int FavoriteGenreId { get; set; }    // Tür Id
    
    public virtual Customer Customer { get; set; } 
}

class UserFavoriteMovieGenresConfigruration : IEntityTypeConfiguration<UserFavoriteMovieGenres>
{
    public void Configure(EntityTypeBuilder<UserFavoriteMovieGenres> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        
        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.FavoriteGenreId).IsRequired();
        
    }
}