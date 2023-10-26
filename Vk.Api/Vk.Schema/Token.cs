public class TokenRequest
{
    public int UserNumber { get; set; }        // Token Numarasi
    public string Password { get; set; }       // Token Password
}

public class TokenResponse
{
    public DateTime ExpireDate { get; set; }
    public string Token { get; set; }
    public int UserNumber { get; set; }
    public string FullName { get; set; }
}