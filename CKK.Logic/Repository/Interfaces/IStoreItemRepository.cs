using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.Interfaces
{
    public interface IStoreItemRepository : IRepository<StoreItem>
    {
        StoreItem Find(int id);
        IEnumerable<StoreItem> Find(string name);
        IEnumerable<StoreItem> GetItemsByQuantity();
        IEnumerable<StoreItem> GetItemsByPrice();
    }
}
