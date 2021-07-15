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
            return Context.Find(i => i.Product.Id == id);
        }

        public StoreItem Find(string name)
        {
            return Context.Find(i => i.Product.Name == name);
        }

        public IEnumerable<StoreItem> GetItemsByQuantity()
        {
            return Context.OrderBy(i => i.Quantity);
        }
    }
}
