using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Find(int id);
        IEnumerable<Product> Find(string name);
        IEnumerable<Product> GetItemsByQuantity();
        IEnumerable<Product> GetItemsByPrice();
    }
}
