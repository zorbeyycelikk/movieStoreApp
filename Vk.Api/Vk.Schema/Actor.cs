namespace Vk.Schema;

public class ActorCreateRequest
{
    
    public int ActorNumber { get; set; }     // Oyuncu Unique Number(Sicil gibi)
    public string ActorFirstName  { get; set; } // Oyuncu Adi
    public string ActorLastName  { get; set; }  // Oyuncu Soy Adi
}

public class ActorUpdateRequest
{
    public string ActorFirstName  { get; set; } // Oyuncu Adi
    public string ActorLastName  { get; set; }  // Oyuncu Soy Adi
}
public class ActorResponse
{
    public int ActorNumber { get; set; }     // Oyuncu Unique Number(Sicil gibi)
    public string ActorFirstName  { get; set; } // Oyuncu Adi
    public string ActorLastName  { get; set; }  // Oyuncu Soy Adi
}