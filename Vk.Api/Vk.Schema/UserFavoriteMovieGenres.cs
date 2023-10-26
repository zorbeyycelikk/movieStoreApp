namespace Vk.Schema;

public class UserFavoriteMovieGenresCreateRequest
{ 
    public int CustomerId  { get; set; }            // Kullanici Id (Foreign From Customer)
    public int FavoriteGenreId     { get; set; }    // Tür Id

}

public class UserFavoriteMovieGenresUpdateRequest
{ 
    public int FavoriteGenreId     { get; set; }    // Tür Id
}

public class UserFavoriteMovieGenresResponse
{ 
    public int CustomerId  { get; set; }            // Kullanici Id (Foreign From Customer)
    public int FavoriteGenreId     { get; set; }    // Tür Id
}