using Vk.Base.Model;

namespace Vk.Data.Domain;

public class Actor : BaseModel
{
    public string ActorFirstName  { get; set; } // Oyuncu Adi
    public string ActorLastName  { get; set; } // Oyuncu Soy Adi
    
    public virtual List<Movie> Movies { get; set; } // Oyuncu bir den çok filmde oynayabilir.
}