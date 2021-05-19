using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace CKK.Tests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void AddProduct_InvalidArgumentGiven()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);

                //Act
                var product = new Product();
                product.SetId(1);
                var actual = cart.AddProduct(product, -5);
                //Assert
                Assert.Null(actual);
            }
            catch
            {
                throw new XunitException("Did not return null when that is what was expected.");
            }
        }
        [Fact]
        public void AddProduct_AddProductWhenFull()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(1);
                var product2 = new Product();
                product2.SetId(2);
                var product3 = new Product();
                product3.SetId(3);

                cart.AddProduct(product1);
                cart.AddProduct(product2);
                cart.AddProduct(product3);
                //Act

                var actual = cart.AddProduct(new Product());

                //Assert
                Assert.Null(actual);
            }
            catch
            {
                throw new XunitException("Did not return null when that is what was expected.");
            }
        }

        [Fact]
        public void AddProduct_AddProductWhenExists()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(1);
                var product2 = new Product();
                product2.SetId(2);
                var product3 = new Product();
                product3.SetId(3);

                cart.AddProduct(product1);
                cart.AddProduct(product2);
                cart.AddProduct(product3);
                //Act
                var returnedItem = cart.AddProduct(product1, 3);
                var expected = 4;


                //Assert
                var actual = cart.GetProductById(1).GetQuantity();
                Assert.Equal(expected, returnedItem.GetQuantity());
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("Did not add item correctly.");
            }
        }
        [Fact]
        public void AddProduct_AddNewProduct()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(1);
                var product2 = new Product();
                product2.SetId(2);
                var product3 = new Product();
                product3.SetId(3);

                cart.AddProduct(product1);
                cart.AddProduct(product2);
                //Act
                var actual = cart.AddProduct(product3, 5).GetQuantity();

                //Assert
                Assert.Equal(5, actual);
            }
            catch
            {
                throw new XunitException("Did not add product correctly");
            }
        }

        [Fact]
        public void GetTotal_ReturnsCorrectAmount()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(1);
                product1.SetPrice(.50m);
                var product2 = new Product();
                product2.SetId(2);
                product2.SetPrice(1);
                var product3 = new Product();
                product3.SetId(3);
                product3.SetPrice(2.50m);

                cart.AddProduct(product1, 2);
                cart.AddProduct(product2, 4);
                cart.AddProduct(product3, 2);
                var expected = 10;
                //Act
                var actual = cart.GetTotal();
                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("Did not return correct total amount.");
            }
        }
        [Fact]
        public void GetProduct_ReturnsCorrectItem()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(1);
                var product2 = new Product();
                product2.SetId(2);
                var product3 = new Product();
                product3.SetId(3);

                cart.AddProduct(product1);
                cart.AddProduct(product2);
                var expected = cart.AddProduct(product3);
                //Act 
                var actual = cart.GetProduct(3);
                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("Did not return the correct item!");
            }
        }
    }
}
