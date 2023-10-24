using Vk.Base.Model;

namespace Vk.Data.Domain;

public class Order : BaseModel
{
        public string   PurchaserCustomer  { get; set; }  // Satın Alan Müşteri İsmi
        public string   PurchasedMovie     { get; set; }  // Satın Alınan Film
        public int      Price              { get; set; }  // Fiyat
        public DateTime PurchaseDate       { get; set; }  // Satin Alma Tarihi
        
        public int CustomerId { get; set; }             // Customer'dan referans alınacak
        public virtual Customer Customers { get; set; } // Musteri bir den çok film satin alabilir.
        
        public int MovieId { get; set; }                // Movide'den ref gelecek
        public virtual List<Movie> Movies { get; set; } //Bir siparişte birden çok film olabilir

}