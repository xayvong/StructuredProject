using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class OrderSummary
    {
        //Add this after we set up Entity Framework (it will auto set the Id for us...)
        //public int Id { get; set; }
        public OrderSummary(Customer cust)
        {
            Cart = new ShoppingCart(cust);
        }

        public OrderSummary(IShoppingCart cart)
        {
            Cart = cart;
        }
        //Only going to have these two things
        public IShoppingCart Cart { get; set; }
        public Customer Customer {
            get
            {
                return Cart.Customer;
            }
            set
            {
                Cart.Customer = value;
            }
        }
        //Order Time data
        //
    }
}
