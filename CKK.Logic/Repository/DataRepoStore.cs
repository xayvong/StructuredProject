using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Logic.Repository.Data;
using CKK.Logic.Repository.Interfaces;
using CKK.Logic.Repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository
{
    public class DataRepoStore : IStore
    {
        private readonly IDataUnitOfWork UOW;
        public void Save()
        {
            UOW.Complete();
        }
        public DataRepoStore()
        {
            CKKDbContext context = new();
            UOW = new DataUnitOfWork(context);
        }
        public Product AddStoreItem(Product prod, int quantity)
        {
            prod.Quantity = quantity;
            UOW.Products.Add(prod);
            UOW.Complete();
            return prod;
        }

        public Product DeleteStoreItem(int id)
        {
            var item = UOW.Products.Find(id);
            if (item != null)
            {
                UOW.Products.Remove(item);
                UOW.Complete();
                return item;
            }
            return null;
           
        }

        public Product FindStoreItemById(int id)
        {
            return UOW.Products.Find(id);
        }

        public List<Product> GetProductsByName(string name)
        {
            return UOW.Products.Find(name).ToList();
        }

        public List<Product> GetProductsByPrice()
        {
            return UOW.Products.GetItemsByPrice().ToList();
        }

        public List<Product> GetProductsByQuantity()
        {
            return UOW.Products.GetItemsByQuantity().ToList();
        }

        public List<Product> GetStoreItems()
        {
            return UOW.Products.GetAll().ToList();
        }

        public Product RemoveStoreItem(int id, int quantity)
        {
            var item = UOW.Products.Find(id);
            if (item != null)
            {
                var result = item.Quantity - quantity;
                if (result > 0)
                {
                    item.Quantity -= quantity;
                }
                else
                {
                    UOW.Products.Remove(item);
                }
                UOW.Complete();
            }
            return item;
        }
    }
}
