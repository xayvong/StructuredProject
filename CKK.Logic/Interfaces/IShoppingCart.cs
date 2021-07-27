using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public interface IShoppingCart
    {
        //Model
        //public int ShoppingCartId { get; set; }
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        //public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        //Methods
        public int GetCustomerId();
        public ShoppingCartItem AddProduct(Product prod, int quantity);
        public ShoppingCartItem RemoveProduct(int id, int quantity);
        public decimal GetTotal();
        public ShoppingCartItem GetProductById(int id);
        public List<ShoppingCartItem> GetProducts();
    }
}
