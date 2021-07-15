using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    [Serializable]
    public class ShoppingCart : IShoppingCart
    {
        
        public Customer Customer { get; set; }
        
        public List<ShoppingCartItem> Products { get; set; }

        public ShoppingCart(Customer customer)
        {
            Customer = customer;
            Products = new List<ShoppingCartItem>();
        }

        public int GetCustomerId()
        {
            return Customer.Id;
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if(quantity <= 0)
            {
                throw new InventoryItemStockTooLowException();
            }
            var existingItem = GetProductById(prod.Id);
            if(existingItem == null)
            {
                var newItem = new ShoppingCartItem(prod, quantity);
                Products.Add(newItem);
                return newItem;
            } else
            { 
                existingItem.Quantity += quantity;
                return existingItem;
            }
        }

        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            if(quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var existingItem = GetProductById(id);
            if (existingItem != null)
            {
                if (existingItem.Quantity - quantity <= 0)
                {
                    existingItem.Quantity = (0);
                    Products.Remove(existingItem);
                }
                else
                {
                    existingItem.Quantity -= quantity;
                }
                return existingItem;
            }
            else
            {
                throw new ProductDoesNotExistException();
            }
        }
        public ShoppingCartItem GetProductById(int id)
        {
            if(id < 0)
            {
                throw new InvalidIdException();
            }
            return Products.FirstOrDefault(p => p.Product.Id == id);            
        }

        public decimal GetTotal()
        {
            var grandTotal = 0m;
            foreach(var product in Products)
            {
                grandTotal += (product.Product.Price * product.Quantity);
            }
            //Products.ForEach(p => grandTotal += p.Product.Price); //Make it all one line using inline foreach
            return grandTotal;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }
    }
}
