using CKK.Logic.Repository.InMemory;
using CKK.Logic.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public InMemoryUnitOfWork()
        {
            Customers = new InMemoryCustomerRepository();
            Orders = new InMemoryOrderRepository();
            Stores = new InMemoryStoreItemRepository();
        }
        public ICustomerRepository Customers { get; }

        public IOrderRepository Orders { get; }

        public IStoreItemRepository Stores { get; }
        

        public int Complete()
        {
            return 0;
        }

        public void Dispose()
        {
            
        }
    }
}
