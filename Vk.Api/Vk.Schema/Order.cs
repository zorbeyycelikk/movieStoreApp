namespace Vk.Schema;

public class OrderListRequest
{
    public string   PurschaseNumber { get; set; }     // Satın Alma Fiş No(unique)
    public string   PurchaserCustomer  { get; set; }  // Satın Alan Müşteri İsmi
    public string   PurchasedMovie     { get; set; }  // Satın Alınan Filmler
    public int      Price              { get; set; }  // Fiyat
    public DateTime PurchaseDate       { get; set; }  // Satin Alma Tarihi
        
    public int CustomerId { get; set; }             // Customer'dan referans alınacak
}


public class OrderListResponse
{
    public string   PurschaseNumber { get; set; }     // Satın Alma Fiş No(unique)
    public string   PurchaserCustomer  { get; set; }  // Satın Alan Müşteri İsmi
    public string   PurchasedMovie     { get; set; }  // Satın Alınan Filmler
    public int      Price              { get; set; }  // Fiyat
    public DateTime PurchaseDate       { get; set; }  // Satin Alma Tarihi
        
    public int CustomerId { get; set; }             // Customer'dan referans alınacak

}