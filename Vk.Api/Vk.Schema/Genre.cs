namespace Vk.Schema;

public class GenreCreateRequest
{
    public int GenreNumber { get; set; }    // Tür Numarasi
    public string GenreName  { get; set; }  // Tür Adi
}

public class GenreUpdateRequest
{
    public string GenreName  { get; set; }  // Tür Adi
}

public class GenreResponse
{
    public int GenreNumber { get; set; }    // Tür Numarasi
    public string GenreName  { get; set; }  // Tür Adi
}