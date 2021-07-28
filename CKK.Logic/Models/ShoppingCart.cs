using System;
using System.Collections.Generic;


namespace CKK.Logic.Models
{
    [Serializable]
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
