using CKK.Logic.Models;
using CKK.Logic.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CKK.Online.Models
{
    public class ShopModel
    {
        public Order Order { get; set; }
        public IDataUnitOfWork UOW { get; set; }
        public ShopModel(IDataUnitOfWork uow)
        {
            UOW = uow;
            Order = uow.Orders.GetOrderById(1);
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
