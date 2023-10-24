using Vk.Base.Model;

namespace Vk.Data.Domain;

public class Genre : BaseModel
{
    public int GenreNumber { get; set; }    // Tür Numarasi
    public string GenreName  { get; set; }  // Tür Adi
    
    public virtual List<Movie> Movies { get; set; } // Bir türde birden çok film olabilir

}