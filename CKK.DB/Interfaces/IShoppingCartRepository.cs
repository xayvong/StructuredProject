using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.DB.Interfaces
{
    public interface IShoppingCartRepository
    {
        public int GetCustomerId(int shoppingCartId);
        public ShoppingCartItem AddtoCart(int ShoppingCardId, int itemId, int quantity);
        public ShoppingCartItem RemoveFromCart(int shoppingCartId,int itemId, int quantity=1);
        public decimal GetTotal(int ShoppingCartId);
        public List<ShoppingCartItem> GetProducts(int shoppingCartId);
        public void Ordered(int shoppingCartId);
        public void Delete();
        public Task<Product> GetById(int id);
    }
}
