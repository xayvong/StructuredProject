using CKK.Logic.Models;
using CKK.Logic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.Data
{
    public class DataProductRepository : DataRepository<Product>, IProductRepository
    {
        public DataProductRepository(DbContext context)
            :base(context)
        {

        }

        public Product Find(int id)
        {
            return Context.Set<Product>().FirstOrDefault(p => p.ProductId == id);
        }

        public IEnumerable<Product> Find(string name)
        {
            return Context.Set<Product>().Where(p => p.Name.ToLower().Contains(name.ToLower()));
        }

        public override IEnumerable<Product> GetAll()
        {
            if(Context is CKKDbContext context)
            {
                return context.Products;
                  //  .Include(product => product.ProductId)
                    //.Include(p => p.Price)
                    //.Include(p => p.Name)
                    //.ToList();
            }
            return Context.Set<Product>()
                //.Include(p => p.ProductId)
                //.Include(p => p.Name)
                //.Include(p => p.Price)
                //.Include(p => p.Quantity)
                .ToList();
        }

        public IEnumerable<Product> GetItemsByPrice()
        {
            return GetAll().OrderBy(p => p.Price);
        }

        public IEnumerable<Product> GetItemsByQuantity()
        {
            return GetAll().OrderByDescending(p => p.Quantity);
        }
    }
}
