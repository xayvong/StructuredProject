using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.Interfaces
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        public int GetCustomerId(int shoppingCartId);
        public ShoppingCartItem AddToCart(int shoppingCartId, int itemId, int quantity);
        public ShoppingCartItem AddToCart(int shoppingCartId, string itemName, int quantity);
        public ShoppingCartItem RemoveFromCart(int shoppingCartId, int itemId, int quantity = 1);
        public decimal GetTotal(int ShoppingCartId);
        public List<ShoppingCartItem> GetProducts(int shoppingCartId);

    }
}
