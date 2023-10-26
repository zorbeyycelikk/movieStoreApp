using Vk.Data.Domain;

namespace Vk.Schema;

public class CustomerCreateRequest
{
    public int    CustomerNumber { get; set; }     // Müsteri Unique Number(Sicil gibi)
    public string CustomerFirstName  { get; set; } // Musteri Adi
    public string CustomerLastName  { get; set; }  // Musteri Soy Adi
}

public class CustomerUpdateRequest
{
    public string CustomerFirstName  { get; set; } // Musteri Adi
    public string CustomerLastName  { get; set; }  // Musteri Soy Adi
}

public class CustomerResponse
{
    public int    CustomerNumber { get; set; }     // Müsteri Unique Number(Sicil gibi)
    public string CustomerFullName { get; set; }   // Mapper'dan gelecek
    public List<UserFavoriteMovieGenresResponse> UserFavoriteMovieGenresList { get; set; } 
}