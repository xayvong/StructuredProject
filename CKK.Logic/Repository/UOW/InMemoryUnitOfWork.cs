using CKK.Logic.Models;
using CKK.Logic.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Repository.UOW
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public InMemoryUnitOfWork()
        {
            //Customers = new InMemoryCustomerRepository();
            //Orders = new InMemoryOrderRepository();
            //StoreItems = new InMemoryStoreItemRepository();

            //Customer cust1 = new Customer() { CustomerId = 1, Address = "123 Maple Street", Name = "John Doe" };
            //Customer cust2 = new Customer() { CustomerId = 2, Address = "456 YellowStone", Name = "Sally Ride" };
            //Customer cust3 = new Customer() { CustomerId = 3, Address = "789 Elm Road", Name = "Megan Trainer" };

            //OrderSummary summary1 = new OrderSummary(cust1);
            //OrderSummary summary2 = new OrderSummary(cust2);
            //OrderSummary summary3 = new OrderSummary(cust3);

            //Product product1 = new Product() { ProductId = 100, Name = "Tires", Price = 3.45m };
            //Product product2 = new Product() { ProductId = 200, Name = "Wheels", Price = 4.25m };
            //Product product3 = new Product() { ProductId = 300, Name = "Nvidia GTX 1050 ti", Price = 50.43m };
            //Product product4 = new Product() { ProductId = 400, Name = "Intel i7 Processor", Price = 20.89m };

            //StoreItem item1 = new StoreItem(product1, 4);
            //StoreItem item2 = new StoreItem(product2, 8);
            //StoreItem item3 = new StoreItem(product3, 2);
            //StoreItem item4 = new StoreItem(product4, 3);

            //Customers.Add(cust1);
            //Customers.Add(cust2);
            //Customers.Add(cust3);

            //Orders.Add(summary1);
            //Orders.Add(summary2);
            //Orders.Add(summary3);

            //StoreItems.Add(item1);
            //StoreItems.Add(item2);
            //StoreItems.Add(item3);
            //StoreItems.Add(item4);

        }
        public ICustomerRepository Customers { get; }

        public IOrderSummaryRepository Orders { get; }

        //public IStoreItemRepository StoreItems { get; }
        

        public int Complete()
        {
            return 0;
        }

        public void Dispose()
        {
            
        }
    }
}
