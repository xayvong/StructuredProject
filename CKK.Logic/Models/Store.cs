using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {
        private List<StoreItem> Items;
        private static int IdCounter = 0;
        public Store()
        {
            Items = new List<StoreItem>();
        }

        public StoreItem AddStoreItem(Product product, int quantity)
        {
            if(quantity < 0)
            {
                throw new InventoryItemStockTooLowException();
            }
            if(product.Id == 0)
            {
                product.Id = (++IdCounter);
            }
            var existingItem = FindStoreItemById(product.Id);
            if(existingItem == null)
            {
                StoreItem newItem = new StoreItem(product, quantity);
                Items.Add(newItem);
                return newItem;
            }else
            {
                existingItem.Quantity = (existingItem.Quantity + quantity);
                return existingItem;
            }
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if(quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var existingItem = FindStoreItemById(id);
            if(existingItem != null)
            {
                if (existingItem.Quantity - quantity < 0)
                {
                    existingItem.Quantity = (0);
                }
                else
                {
                    existingItem.Quantity = (existingItem.Quantity - quantity);
                }
                return existingItem;
            }else
            {
                throw new ProductDoesNotExistException();
            }
        }

        public StoreItem DeleteStoreItem(int id)
        {

            var existingItem = FindStoreItemById(id);
            if(existingItem != null)
            {
                Items.Remove(existingItem);
            }
            return existingItem;
        }

        public StoreItem FindStoreItemById(int id)
        {
            if(id < 0)
            {
                throw new InvalidIdException();
            }
            return Items.FirstOrDefault(p => p.Product.Id == id);            
        }

        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }

        public List<StoreItem> GetProductsByQuantity()
        {
            return new List<StoreItem>(Items.OrderByDescending(t => t.Quantity));
        }

        public List<StoreItem> GetProductsByPrice()
        {
            return new List<StoreItem>(Items.OrderByDescending(t => t.Product.Price));
        }

        public List<StoreItem> GetProductsByName(string name)
        {
            return new List<StoreItem>(Items.Where(i => i.Product.Name.ToLower().Contains(name)));
        }
    }
}
