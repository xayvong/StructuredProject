using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
 
        public override string ToString() => $"#{Id,-4}  {Name,-30} {$"Quantity: {Quantity:N0}",-13}";
    }
}
