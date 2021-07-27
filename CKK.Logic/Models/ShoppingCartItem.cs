using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    [Serializable]
    public class ShoppingCartItem : InventoryItem
    {
        public int ShoppingCartItemId { get; set; }
        public List<ShoppingCart> Carts {get; set;} = new List<ShoppingCart>();

        public decimal GetTotal()
        {
            return Product.Price * Quantity;
        }
    }
}
