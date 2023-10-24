using Vk.Base.Model;

namespace Vk.Data.Domain;

public class Director : BaseModel
{
    public string DirectorFirstName  { get; set; } // Yönetmen Adi
    public string DirectorLastName  { get; set; } // Yönetmen Soy Adi
    
    public virtual List<Movie> Movies { get; set; } // Yönetmen birden çok film yönetebilir.
}