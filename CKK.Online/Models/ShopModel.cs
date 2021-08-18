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
            Order = uow.Orders.GetByIdAsync(1).Result;
            /*//one time set up...
            var customer = new Customer { Address = "1234 Dreary Way", Name = "John Doe" };
            var cart = new ShoppingCart { Customer = customer };
            var order = new Order { ShoppingCart = cart };
            uow.Orders.Add(order);
            uow.Complete();
            Order = order;*/
        }
    }
}
