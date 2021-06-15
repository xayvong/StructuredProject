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
            if(product.GetId() == 0)
            {
                product.SetId(++IdCounter);
            }
            var existingItem = FindStoreItemById(product.GetId());
            if(existingItem == null)
            {
                StoreItem newItem = new StoreItem(product, quantity);
                Items.Add(newItem);
                return newItem;
            }else
            {
                existingItem.SetQuantity(existingItem.GetQuantity() + quantity);
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
                if (existingItem.GetQuantity() - quantity < 0)
                {
                    existingItem.SetQuantity(0);
                }
                else
                {
                    existingItem.SetQuantity(existingItem.GetQuantity() - quantity);
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
            return Items.FirstOrDefault(p => p.GetProduct().GetId() == id);            
        }

        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }
        
    }
}
