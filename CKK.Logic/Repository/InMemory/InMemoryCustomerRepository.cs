using CKK.Logic.Models;
using CKK.Logic.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.InMemory
{
    public class InMemoryCustomerRepository : InMemoryRepository<Customer>, ICustomerRepository
    {
        public InMemoryCustomerRepository() 
            : base(new List<Customer>())
        {

        }
        public Customer Find(int id)
        {
            return Context.Find(i => i.CustomerId == id);
        }
    }
}
