using System.Text.Json.Serialization;

namespace CKK.Logic.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [JsonIgnore]
        public ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
