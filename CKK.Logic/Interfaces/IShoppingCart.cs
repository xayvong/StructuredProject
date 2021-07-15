﻿using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public interface IShoppingCart
    {
        public Customer Customer { get; set; }
        public int GetCustomerId();
        public ShoppingCartItem AddProduct(Product prod, int quantity);
        public ShoppingCartItem RemoveProduct(int id, int quantity);
        public decimal GetTotal();
        public ShoppingCartItem GetProductById(int id);
        public List<ShoppingCartItem> GetProducts();
    }
}
