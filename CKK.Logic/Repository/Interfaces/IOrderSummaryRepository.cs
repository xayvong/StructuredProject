using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.Interfaces
{
    public interface IOrderSummaryRepository : IRepository<OrderSummary>
    {
        OrderSummary GetOrderByCustomerId(int id);
        //Wait till we set up Entity Framework to put Id in...
        //OrderSummary GetOrderById(int id);
    }
}
