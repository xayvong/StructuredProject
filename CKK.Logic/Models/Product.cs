using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Product : Entity
    {
        public int ProductId { get; set; }
        private decimal price;
        public decimal Price {
            get
            {
                return price;
            }
            set
            {
                if (value >= 0)
                {
                    price = value;
                } else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public int Quantity { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public override string ToString() => $"#{ProductId,-4}  {Name,-30} {$"Quantity: {Quantity:N0}",-13}";
    }
}
