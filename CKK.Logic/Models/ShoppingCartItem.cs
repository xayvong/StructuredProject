using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCartItem : InventoryItem
    {
        public ShoppingCartItem(Product product, int quantity)
        {
            SetProduct(product);
            SetQuantity(quantity);
        }
        public decimal GetTotal()
        {
            return GetProduct().GetPrice() * GetQuantity();
        }
    }
}
