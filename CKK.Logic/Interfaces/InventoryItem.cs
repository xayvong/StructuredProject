using CKK.Logic.Exceptions;
using CKK.Logic.Models;
using System;
using System.Collections.Generic;
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
        public int Quantity {
            get
            {
                return quantity;
            }
            set
            {
                if (value >= 0)
                {
                    quantity = value;
                } else
                {
                    throw new InventoryItemStockTooLowException();
                }
            }
        }

        public Product GetProduct()
        {
            return Product;
        }

        public void SetProduct(Product product)
        {
            Product = product;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
        public override string ToString() => $"#{Product.GetId(),-4}  {Product.GetName(),-30} {$"Quantity: {Quantity:N0}",-13}";
    }
}
