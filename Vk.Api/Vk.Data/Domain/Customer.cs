using Vk.Base.Model;

namespace Vk.Data.Domain;

public class Customer : BaseModel
{
    public string CustomerFirstName  { get; set; } // Musteri Adi
    public string CustomerLastName  { get; set; } // Musteri Soy Adi
    
    public virtual List<Order> Orders { get; set; } // Musteri bir den çok siparişi olabilir.
}