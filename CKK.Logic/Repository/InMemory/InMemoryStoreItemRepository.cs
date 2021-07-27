using CKK.Logic.Models;
using CKK.Logic.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.InMemory
{
    public class InMemoryStoreItemRepository : InMemoryRepository<StoreItem>, IStoreItemRepository
    {
        public InMemoryStoreItemRepository() 
            :base(new List<StoreItem>())
        {

        }

        public StoreItem Find(int id)
        {
            return Context.Find(i => i.Product.ProductId == id);
        }

        public IEnumerable<StoreItem> Find(string name)
        {
            return Context.Where(i => i.Product.Name.ToLower().Contains(name.ToLower()));
        }

        public IEnumerable<StoreItem> GetItemsByQuantity()
        {
            return Context.OrderBy(i => i.Quantity);
        }
        public IEnumerable<StoreItem> GetItemsByPrice()
        {
            return Context.OrderByDescending(i => i.Product.Price);
        }
    }
}
