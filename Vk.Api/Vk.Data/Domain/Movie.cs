using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vk.Base.Model;

namespace Vk.Data.Domain;

[Table("Movie", Schema = "dbo")]
public class Movie : BaseModel
{
    public int    MovieNumber  { get; set; }   // Film Numarasi
    public string MovieName    { get; set; }   // Film Adi
    public int    MovieYear    { get; set; }   // Film Yili
    public int    Price        { get; set; }
    public int    GenreId      { get; set; }   // Film 'in bir tane türü olur
    public int    DirectorId   { get; set; }   // Foreign Key ile gelecek.(DirectorNumber)
    
    public virtual Genre Genre { get; set; }
    public virtual Director Director { get; set; }  // Film'in bir tane yönetmeni olur
    public virtual List<Actor> Actors { get; set; } // Filmde bir den çok oyuncu olabilir
}

class MovieConfigruration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        
        builder.Property(x => x.MovieNumber).IsRequired();
        builder.Property(x => x.MovieName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.MovieYear).IsRequired().HasMaxLength(4);
        
        builder.Property(x => x.GenreId).IsRequired();
        builder.Property(x => x.DirectorId).IsRequired();
        
        builder.HasIndex(x => x.MovieNumber);
        
        builder.HasOne(x => x.Director)
            .WithMany(x => x.Movies) 
            .HasForeignKey(x => x.DirectorId)
            .HasPrincipalKey(c => c.DirectorNumber)
            .IsRequired(true);
        
        builder.HasOne(x => x.Genre)
            .WithMany(x => x.Movies) 
            .HasForeignKey(x => x.GenreId)
            .HasPrincipalKey(c => c.GenreNumber)
            .IsRequired(true);
    }
}