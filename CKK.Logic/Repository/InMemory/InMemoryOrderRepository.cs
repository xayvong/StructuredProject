using CKK.Logic.Models;
using CKK.Logic.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.InMemory
{
    public class InMemoryOrderRepository : InMemoryRepository<OrderSummary>, IOrderRepository
    {

        public InMemoryOrderRepository()
            : base(new List<OrderSummary>())
        {

        }

        public OrderSummary GetOrderByCustomerId(int id)
        {
            return Context.Find(i => i.Customer.Id == id);
        }
    }
}
