using CKK.Logic.Models;
using CKK.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKK.Online.Models
{
    public class ShopModel
    {
        public Order Order { get; set; }
        public IUnitOfWork UOW { get; set; }
        public ShopModel(IUnitOfWork uow)
        {
            UOW = uow;
            if (UOW.Orders.GetByIdAsync(1).Result == null)
            {
                //Testing to see if order gets added in
                Order newOrder = new();
                UOW.Orders.CreateOrder(newOrder);
            }
            Order = uow.Orders.GetByIdAsync(1).Result;

        }
    }
}
