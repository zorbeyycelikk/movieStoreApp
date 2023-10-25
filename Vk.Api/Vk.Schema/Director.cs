namespace Vk.Schema;

public class DirectorCreateRequest
{
    public int DirectorNumber { get; set; }     // Yonetmen Unique Number(Sicil gibi)
    public string DirectorFirstName  { get; set; } // Yönetmen Adi
    public string DirectorLastName  { get; set; } // Yönetmen Soy Adi
}

public class DirectorUpdateRequest
{
    public string DirectorFirstName  { get; set; } // Yönetmen Adi
    public string DirectorLastName  { get; set; } // Yönetmen Soy Adi
}

public class DirectorResponse
{
    public int DirectorNumber { get; set; }     // Yonetmen Unique Number(Sicil gibi)
    public string DirectorFirstName  { get; set; } // Yönetmen Adi
    public string DirectorLastName  { get; set; } // Yönetmen Soy Adi
}