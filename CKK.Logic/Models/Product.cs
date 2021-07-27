using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    [Serializable]
    public class Product : Entity
    {
        [Key]
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
    }
}
