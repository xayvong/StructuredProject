using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer Customer;
        private ShoppingCartItem product1;
        private ShoppingCartItem product2;
        private ShoppingCartItem product3;

        public ShoppingCart(Customer customer)
        {
            Customer = customer;
        }

        public int GetCustomerId()
        {
            return Customer.GetId();
        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }
            if (product1 != null && product1.GetProduct().GetId() == prod.GetId())
            {
                //If product1 == prod
                product1.SetQuantity(product1.GetQuantity() + quantity);
                return product1;
            }
            else if (product2 != null && product2.GetProduct().GetId() == prod.GetId())
            {
                //If product2 == prod
                product2.SetQuantity(product1.GetQuantity() + quantity);
                return product2;
            }
            else if (product3 != null && product3.GetProduct().GetId() == prod.GetId())
            {
                //If product3 == prod
                product3.SetQuantity(product3.GetQuantity() + quantity);
                return product3;
            }

            //If it does not already exist, check if there is a spot open
            if (product1 == null)
            {
                product1 = new ShoppingCartItem(prod, quantity);
                return product1;
            }
            if (product2 == null)
            {
                product2 = new ShoppingCartItem(prod, quantity);
                return product2;
            }
            if (product3 == null)
            {
                product3 = new ShoppingCartItem(prod, quantity);
                return product3;
            }
            //If all of the spots are full
            return null;
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);
        }

        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                return null;
            }
            if (product1 != null && product1.GetProduct().GetId() == prod.GetId())
            {
                //If product1 == prod
                product1.SetQuantity(product1.GetQuantity() - quantity);
                if (product1.GetQuantity() < 1)
                {
                    return null;
                }
                return product1;
            }
            else if (product2 != null && product2.GetProduct().GetId() == prod.GetId())
            {
                //If product2 == prod
                product2.SetQuantity(product1.GetQuantity() - quantity);
                if (product2.GetQuantity() < 1)
                {
                    return null;
                }
                return product2;
            }
            else if (product3 != null && product3.GetProduct().GetId() == prod.GetId())
            {
                //If product3 == prod
                product3.SetQuantity(product3.GetQuantity() - quantity);
                if (product3.GetQuantity() < 1)
                {
                    return null;
                }
                return product3;
            }
            return null;
        }

        public decimal GetTotal()
        {
            var grandTotal = 0m;
            if (product1 != null)
            {
                grandTotal += product1.GetTotal();
            }
            if (product2 != null)
            {
                grandTotal += product2.GetTotal();
            }
            if (product3 != null)
            {
                grandTotal += product3.GetTotal();
            }
            return grandTotal;
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (product1.GetProduct().GetId() == id)
            {
                return product1;
            }
            else if (product2.GetProduct().GetId() == id)
            {
                return product2;
            }
            else if (product3.GetProduct().GetId() == id)
            {
                return product3;
            }
            else
            {
                return null;
            }
        }

        public ShoppingCartItem GetProduct(int productNumber)
        {
            if (productNumber == 1)
            {
                return product1;
            }
            if (productNumber == 2)
            {
                return product2;
            }
            if (productNumber == 3)
            {
                return product3;
            }
            else
            {
                return null;
            }
        }
    }
}
