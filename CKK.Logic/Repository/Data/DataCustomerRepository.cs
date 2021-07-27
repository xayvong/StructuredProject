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
    public class DataCustomerRepository : DataRepository<Customer>, ICustomerRepository
    {
        public DataCustomerRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<Customer> GetAll()
        {
            return Context.Set<Customer>()
                .Include(c => c.Address)
                .Include(c => c.Cart)
                .Include(c => c.CustomerId)
                .Include(c => c.Name);
        }

        public Customer Find(int id)
        {
            return Context.Set<Customer>().FirstOrDefault(c => c.CustomerId == id);
        }




    }
}
