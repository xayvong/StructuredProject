using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public interface IStore
    {
        public Product AddStoreItem(Product prod, int quantity);
        public Product RemoveStoreItem(int id, int quantity);
        public Product DeleteStoreItem(int id);
        public Product FindStoreItemById(int id);
        public List<Product> GetStoreItems();
        public List<Product> GetProductsByName(string name);
        public List<Product> GetProductsByQuantity();
        public List<Product> GetProductsByPrice();
    }
}
