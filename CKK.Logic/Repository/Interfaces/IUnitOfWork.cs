using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IStoreItemRepository Stores { get; }
        int Complete();
    }
}
