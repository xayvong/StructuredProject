using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Logic.Repository.Interfaces;
using CKK.Logic.Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository
{
    public class InMemoryRepoStore : IStore
    {
        private readonly IUnitOfWork unitOfWork;
        public InMemoryRepoStore()
        {
            unitOfWork = new InMemoryUnitOfWork();
        }
        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            StoreItem addedItem = new StoreItem(prod, quantity);
            unitOfWork.StoreItems.Add(addedItem);
            return addedItem;
        }

        public StoreItem DeleteStoreItem(int id)
        {
            var foundItem = unitOfWork.StoreItems.Find(id);            
            unitOfWork.StoreItems.Remove(foundItem); 
            return foundItem;
        }

        public StoreItem FindStoreItemById(int id)
        {
            return unitOfWork.StoreItems.Find(id);
        }

        public List<StoreItem> GetProductsByName(string name)
        {
            return new List<StoreItem>(unitOfWork.StoreItems.Find(name));
        }

        public List<StoreItem> GetProductsByPrice()
        {
            return new List<StoreItem>(unitOfWork.StoreItems.GetItemsByPrice());
        }

        public List<StoreItem> GetProductsByQuantity()
        {
            return new List<StoreItem>(unitOfWork.StoreItems.GetItemsByQuantity());
        }

        public List<StoreItem> GetStoreItems()
        {
            return new List<StoreItem>(unitOfWork.StoreItems.GetAll());
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            var foundItem = unitOfWork.StoreItems.Find(id);
            foundItem.Quantity -= quantity;
            return foundItem;
        }
        public void Save()
        {
            unitOfWork.Complete();
        }
    }
}
