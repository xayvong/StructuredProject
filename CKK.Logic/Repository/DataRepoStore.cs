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
            CKKDbContext context = new CKKDbContext();
            UOW = new DataUnitOfWork(context);
        }
        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            prod.Quantity = quantity;
            UOW.Products.Add(prod);
            UOW.Complete();
            return prod.Convert();
        }

        public StoreItem DeleteStoreItem(int id)
        {
            var item = UOW.Products.Find(id);
            if (item != null)
            {
                UOW.Products.Remove(item);
                UOW.Complete();
                return item.Convert();
            }
            return null;
           
        }

        public StoreItem FindStoreItemById(int id)
        {
            return UOW.Products.Find(id).Convert();
        }

        public List<StoreItem> GetProductsByName(string name)
        {
            return UOW.Products.Find(name).Convert();
        }

        public List<StoreItem> GetProductsByPrice()
        {
            return UOW.Products.GetItemsByPrice().Convert();    
        }

        public List<StoreItem> GetProductsByQuantity()
        {
            return UOW.Products.GetItemsByQuantity().Convert();
        }

        public List<StoreItem> GetStoreItems()
        {
            return UOW.Products.GetAll().Convert();
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
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
            return item.Convert();
        }
    }
    public static class ProductExtension
    {
        public static StoreItem Convert(this Product prod)
        {
            return new StoreItem(prod, prod.Quantity);
        }
        public static List<StoreItem> Convert(this IEnumerable<Product> prods)
        {
            var output = new List<StoreItem>();
            foreach(var prod in prods)
            {
                output.Add(prod.Convert());
            }
            return output;
        }
    }
}
