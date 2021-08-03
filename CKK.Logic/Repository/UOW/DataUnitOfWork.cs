using CKK.Logic.Repository.Data;
using CKK.Logic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.UOW
{
    public class DataUnitOfWork : IDataUnitOfWork
    {
        private readonly CKKDbContext Context;
        public DataUnitOfWork(CKKDbContext context)
        {
            Context = context;
            ShoppingCarts = new DataShoppingCartRepository(context);
            Products = new DataProductRepository(context);
            Orders = new DataOrderRepository(context);
            Customers = new DataCustomerRepository(context);
        }
        public IShoppingCartRepository ShoppingCarts { get; private set; }

        public IProductRepository Products { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
        public int Complete()
        {
            return Context.SaveChanges();
        }
    }
}
