﻿using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public abstract class InventoryItem
    {
        protected Product Product;
        protected int Quantity;

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
    }
}
