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
                Assert.Empty(cart.GetProducts());
            }
            catch
            {
                throw new XunitException("Did not populate the cart correctly!");
            }
        }

        [Fact]
        public void AddProduct_ShouldAddNewItem()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product = new Product();
                product.SetId(5);
                //Act
                var expected = cart.AddProduct(product, 5);

                //Assert
                Assert.Single(cart.GetProducts());
                Assert.Equal(expected, cart.GetProductById(5));
            }
            catch
            {
                throw new XunitException("The product was not added correctly to the List.");
            }
        }
        [Fact]
        public void AddProduct_ShouldAddQuantity()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product = new Product();
                product.SetId(5);
                //Act
                cart.AddProduct(product, 5);
                cart.AddProduct(product, 1);

                var expected = 6;
                var actual = cart.GetProductById(5).GetQuantity();

                //Assert
                Assert.Single(cart.GetProducts());
                Assert.Equal(expected,actual);
            }
            catch
            {
                throw new XunitException("The product was not added correctly to the List.");
            }
        }




        [Fact]
        public void AddProduct_ShouldAddNewItemWithMultiple()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(5);
                var product2 = new Product();
                product2.SetId(2);

                //Act
                cart.AddProduct(product1, 3);
                cart.AddProduct(product2, 9);
                cart.AddProduct(product1, 3);

                var expected = 6;
                var actual = cart.GetProductById(5).GetQuantity();
                //Assert

                Assert.Collection(cart.GetProducts(),
                    elem1 => {
                        Assert.Equal(5, elem1.GetProduct().GetId());
                        Assert.Equal(expected, elem1.GetQuantity());
                    },
                    elem2 =>
                    {
                        Assert.Equal(2, elem2.GetProduct().GetId());
                        Assert.Equal(9, elem2.GetQuantity());
                    }
                    );
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The product was not populated correctly.");
            }
        }

        [Fact]
        public void RemoveProduct_ShouldRemoveItemCorrectly()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(5);
                var product2 = new Product();
                product2.SetId(2);
                var product3 = new Product();
                product3.SetId(3);

                cart.AddProduct(product1, 2);
                cart.AddProduct(product2, 3);
                cart.AddProduct(product3, 8);


                //Act
                var actual = cart.RemoveProduct(3, 4);

                //Assert
                Assert.Collection(cart.GetProducts(),
                    elem1 =>
                    {
                        Assert.Equal(5, elem1.GetProduct().GetId());
                        Assert.Equal(2, elem1.GetQuantity());
                    },
                    elem2 =>
                    {
                        Assert.Equal(2, elem2.GetProduct().GetId());
                        Assert.Equal(3, elem2.GetQuantity());
                    },
                    elem3 =>
                    {
                        Assert.Equal(3, elem3.GetProduct().GetId());
                        Assert.Equal(4, elem3.GetQuantity());
                    });
                Assert.Equal(cart.GetProductById(3), actual);
            }
            catch
            {
                throw new XunitException("The item was not removed correctly");
            }
        }

        [Fact]
        public void RemoveProduct_ShouldRemoveButReturnEmptyProduct()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(5);
                var product2 = new Product();
                product2.SetId(2);
                var product3 = new Product();
                product3.SetId(3);

                cart.AddProduct(product1, 2);
                cart.AddProduct(product2, 3);
                cart.AddProduct(product3, 8);

                //Act
                var actual = cart.RemoveProduct(3, 8);

                //Assert
                Assert.Collection(cart.GetProducts(),
                    elem1 =>
                    {
                        Assert.Equal(5, elem1.GetProduct().GetId());
                        Assert.Equal(2, elem1.GetQuantity());
                    },
                    elem2 =>
                    {
                        Assert.Equal(2, elem2.GetProduct().GetId());
                        Assert.Equal(3, elem2.GetQuantity());
                    });
                Assert.Equal(0, actual.GetQuantity());
            }
            catch
            {
                throw new XunitException("The item returned had incorrect quantity, or was still in the list.");
            }
        }


        [Fact]
        public void RemoveProduct_ShouldRemoveEmtpyProduct()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(5);
                var product2 = new Product();
                product2.SetId(2);
                var product3 = new Product();
                product3.SetId(3);

                cart.AddProduct(product1, 2);
                cart.AddProduct(product2, 3);
                cart.AddProduct(product3, 8);

                //Act
                var actual = cart.RemoveProduct(3, 8);

                //Assert
                Assert.Collection(cart.GetProducts(),
                    elem1 =>
                    {
                        Assert.Equal(5, elem1.GetProduct().GetId());
                        Assert.Equal(2, elem1.GetQuantity());
                    },
                    elem2 =>
                    {
                        Assert.Equal(2, elem2.GetProduct().GetId());
                        Assert.Equal(3, elem2.GetQuantity());
                    });
                Assert.Equal(0,actual.GetQuantity());
            }
            catch
            {
                throw new XunitException("The item was not removed correctly");
            }
        }

        [Fact]
        public void RemoveProduct_ShouldRemoveIfQuantityIsNegative()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(5);
                var product2 = new Product();
                product2.SetId(2);
                var product3 = new Product();
                product3.SetId(3);

                cart.AddProduct(product1, 2);
                cart.AddProduct(product2, 3);
                cart.AddProduct(product3, 8);

                //Act
                var actual = cart.RemoveProduct(3, 18);

                //Assert
                Assert.Collection(cart.GetProducts(),
                    elem1 =>
                    {
                        Assert.Equal(5, elem1.GetProduct().GetId());
                        Assert.Equal(2, elem1.GetQuantity());
                    },
                    elem2 =>
                    {
                        Assert.Equal(2, elem2.GetProduct().GetId());
                        Assert.Equal(3, elem2.GetQuantity());
                    });
                Assert.Equal(0, actual.GetQuantity());
            }
            catch
            {
                throw new XunitException("The item was not removed correctly");
            }
        }

        [Fact]
        public void FindStoreItemById_ShouldReturnCorrectItem()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(5);
                var product2 = new Product();
                product2.SetId(2);

                //Act
                var expected = cart.AddProduct(product1, 3);
                cart.AddProduct(product2, 9);


                //Act
                var actual = cart.GetProductById(5);

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The correct Item was not returned!");
            }
        }

        [Fact]
        public void FindStoreItemById_ShouldReturnNull()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(5);

                //Act
                cart.AddProduct(product1, 40);

                //Assert
                Assert.Null(cart.GetProductById(1));
            }
            catch
            {
                throw new XunitException("The correct value was not given! Should have returned null.");
            }
        }

        [Fact]
        public void FindStoreItemById_ShouldReturnEmptyStoreItem()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                cust.SetId(1);
                ShoppingCart cart = new ShoppingCart(cust);
                var product1 = new Product();
                product1.SetId(100);
                //Act
                cart.AddProduct(product1, 40);
                cart.RemoveProduct(100, 50);

                //Assert
                Assert.Null(cart.GetProductById(100));
            }
            catch
            {
                throw new XunitException("Was expecting null but was given a value. ");
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
        public void GetProducts_ReturnsCorrectItems()
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
                //Act

                var item1 = cart.AddProduct(product1, 1);
                var item2 = cart.AddProduct(product2, 2);
                var item3 = cart.AddProduct(product3, 3);

                //Assert
                Assert.Collection(
                    cart.GetProducts(),
                    elem1 => Assert.Equal(item1, elem1), 
                    elem2 => Assert.Equal(item2, elem2),
                    elem3 => Assert.Equal(item3, elem3));
            }
            catch
            {
                throw new XunitException("Did not return the correct items!");
            }
        }
    }
}
