using Vk.Base.Model;

namespace Vk.Data.Domain;

public class Movie : BaseModel
{
    public string MovieName  { get; set; } // Film Adi
    public int    MovieYear  { get; set; } // Film Yili
    
    public string MovieGenre { get; set; } // Film 'in bir tane türü olur
    public virtual Genre Genre { get; set; }
    
    public int DirectorId { get; set; } // Foreign Key ile gelecek.
    public virtual Director Director { get; set; }  // Film'in bir tane yönetmeni olur
    
    public virtual List<Actor> Actors { get; set; } // Filmde bir den çok oyuncu olabilir
    
}