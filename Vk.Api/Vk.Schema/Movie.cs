namespace Vk.Schema;

public class MovieCreateRequest
{
    public int MovieNumber { get; set; }   // Film Numarasi
    public string MovieName  { get; set; } // Film Adi
    public int    MovieYear  { get; set; } // Film Yili
    
    public int GenreId { get; set; } // Film 'in bir tane türü olur
    public int DirectorId { get; set; }    // Foreign Key ile gelecek.(DirectorNumber)
}

public class MovieUpdateRequest
{
    public string MovieName  { get; set; } // Film Adi
    public int    MovieYear  { get; set; } // Film Yili
}

public class MovieResponse
{
    public int MovieNumber { get; set; }   // Film Numarasi
    public string MovieName  { get; set; } // Film Adi
    public int    MovieYear  { get; set; } // Film Yili
    
    public int GenreId { get; set; } // Film 'in bir tane türü olur
    public int DirectorId { get; set; }    // Foreign Key ile gelecek.(DirectorNumber)
}

