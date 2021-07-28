namespace CKK.Logic.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartId { get; set; }
    }
}
