using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private Customer Customer;
        private List<ShoppingCartItem> Products;

        public ShoppingCart(Customer customer)
        {
            Customer = customer;
            Products = new List<ShoppingCartItem>();
        }

        public int GetCustomerId()
        {
            return Customer.GetId();
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if(quantity <= 0)
            {
                throw new InventoryItemStockTooLowException();
            }
            var existingItem = GetProductById(prod.GetId());
            if(existingItem == null)
            {
                var newItem = new ShoppingCartItem(prod, quantity);
                Products.Add(newItem);
                return newItem;
            } else
            { 
                existingItem.SetQuantity(existingItem.GetQuantity() + quantity);
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
                if (existingItem.GetQuantity() - quantity <= 0)
                {
                    existingItem.SetQuantity(0);
                    Products.Remove(existingItem);
                }
                else
                {
                    existingItem.SetQuantity(existingItem.GetQuantity() - quantity);
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
            return Products.FirstOrDefault(p => p.GetProduct().GetId() == id);            
        }

        public decimal GetTotal()
        {
            var grandTotal = 0m;
            foreach(var product in Products)
            {
                grandTotal += (product.GetProduct().GetPrice() * product.GetQuantity());
            }
            //Products.ForEach(p => grandTotal += p.GetProduct().GetPrice()); //Make it all one line using inline foreach
            return grandTotal;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }
    }
}
