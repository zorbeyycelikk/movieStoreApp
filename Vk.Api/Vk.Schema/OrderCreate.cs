using Vk.Data.Domain;

namespace Vk.Schema;

public class OrderCreateRequest
{
    public int    CustomerId          { get; set; }          
    public int    PurshchaseMovieId   { get; set; }    
    

}

public class OrderResponse
{
    public string   PurschaseNumber { get; set; }     // Satın Alma Fiş No(unique)
    public string   PurchaserCustomer  { get; set; }  // Satın Alan Müşteri İsmi
    public string   PurchasedMovie     { get; set; }  // Satın Alınan Filmler
    public int      Price              { get; set; }  // Fiyat
}