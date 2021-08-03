using CKK.Logic.Models;
using CKK.Logic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.Data
{
    public class DataShoppingCartRepository : DataRepository<ShoppingCart>, IShoppingCartRepository
    {
        public DataShoppingCartRepository(DbContext context) 
            :base(context)
        {

        }

        public ShoppingCart Find(int id)
        {
            return GetAll().Where(s => s.ShoppingCartId == id).FirstOrDefault();
        }

        public ShoppingCartItem AddToCart(int shoppingCartId, int itemId, int quantity)
        {
            var cart = Find(shoppingCartId);
            var product = Context.Set<Product>().FirstOrDefault(i => i.ProductId == itemId);
            if(product == null)
            {
                return null;
            }
            var foundShoppingItem = cart.ShoppingCartItems.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
            if (foundShoppingItem != null)
            {
                foundShoppingItem.Quantity = quantity;
            }
            else
            {
                foundShoppingItem = new ShoppingCartItem() { Product = product, Quantity = quantity };
                cart.ShoppingCartItems.Add(foundShoppingItem);
            }                        
            return foundShoppingItem;
        }
        public ShoppingCartItem AddToCart(int shoppingCartId, string itemName, int quantity)
        {
            return AddToCart(shoppingCartId, Context.Set<Product>().FirstOrDefault(i => i.Name == itemName).ProductId, quantity);
        }

        public override IEnumerable<ShoppingCart> GetAll()
        {
            return Context.Set<ShoppingCart>()
                .Include(cart => cart.Customer)
                .Include(cart => cart.ShoppingCartItems)
                .ThenInclude(x => x.Product);
        }

        public int GetCustomerId(int ShoppingCartId)
        {
            return Find(c => c.ShoppingCartId == ShoppingCartId).FirstOrDefault().CustomerId;
        }

        public List<ShoppingCartItem> GetProducts(int shoppingCartId)
        {
            return Find(f => f.ShoppingCartId == shoppingCartId).FirstOrDefault().ShoppingCartItems;
        }

        public decimal GetTotal(int shoppingCartId)
        {
            var total = 0m;
            var cart = Find(shoppingCartId);
            foreach(var item in cart.ShoppingCartItems)
            {
                total += item.Product.Price * item.Quantity;
            }
            return total;
        }

        public ShoppingCartItem RemoveFromCart(int shoppingCartId, int itemId, int quantity = 1)
        {
            var cart = Find(f => f.ShoppingCartId == shoppingCartId).FirstOrDefault();
            var matchingItem = cart.ShoppingCartItems.Where(f => f.ShoppingCartItemId == itemId).FirstOrDefault();
            var result = matchingItem.Quantity - quantity;
            if(result > 0)
            {
                matchingItem.Quantity -= quantity;
            }else
            {
                matchingItem.Quantity = 0;
                cart.ShoppingCartItems.Remove(matchingItem);
            }
            return matchingItem;
        }
    }
}
