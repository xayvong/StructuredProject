using CKK.Logic.Exceptions;
using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    [Serializable]
    public abstract class InventoryItem
    {
        private int quantity;
        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value >= 0)
                {
                    quantity = value;
                }
                else
                {
                    throw new InventoryItemStockTooLowException();
                }
            }
        }

        public override string ToString() => $"#{Product.ProductId,-4}  {Product.Name,-30} {$"Quantity: {Product.Quantity:N0}",-13}";
    }
}
