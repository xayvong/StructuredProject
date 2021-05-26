using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store : Entity
    {
        private List<StoreItem> Items;

        public Store()
        {
            Items = new List<StoreItem>();
        }

        public StoreItem AddStoreItem(Product product, int quantity)
        {
            if(quantity < 0)
            {
                return null;
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
                return null;
            }
        }

        public StoreItem FindStoreItemById(int id)
        {
            return Items.FirstOrDefault(p => p.GetProduct().GetId() == id);
        }

        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }
        
    }
}
