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
    public class DataOrderRepository : DataRepository<Order>, IOrderRepository
    {
        public DataOrderRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<Order> GetAll()
        {
            return Context.Set<Order>()
                .Include(s => s.OrderId)
                .Include(s => s.ShoppingCart)
                .ThenInclude(c => c.ShoppingCartItems)
                .ThenInclude(c => c.Product);
        }

        public Order GetOrderById(int id)
        {
            return Context.Set<Order>().FirstOrDefault(p => p.OrderId == id);
        }
    }
}
