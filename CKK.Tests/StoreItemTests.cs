using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace CKK.Tests
{
    public class StoreItemTests
    {
        [Fact]
        public void Constructor_SetsProductCorrectly()
        {
            try
            {
                //Assemble
                Product testProduct = new Product();
                testProduct.Id = (1);
                var cartItem = new StoreItem(testProduct, 1);
                //Act
                var actual = cartItem.Product;
                //Assert
                Assert.Equal(testProduct, actual);
            }
            catch
            {
                throw new XunitException("You probably don't have the correct constructor or methods.");
            }
        }

        [Fact]
        public void Constructor_SetsQuantityCorrectly()
        {
            try
            {
                //Assemble
                Product testProduct = new Product();
                testProduct.Id = (2);
                var expected = 24;
                var cartItem = new StoreItem(testProduct, expected);
                //Act
                var actual = cartItem.Quantity;

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("You probably don't have the correct constructor or right methods.");
            }
        }

        [Fact]
        public void GetSetProduct_ShouldSetAndReturnCorrectProduct()
        {
            try
            {
                //Assemble
                var testProduct = new Product();
                var expected = new Product();
                var cartItem = new StoreItem(testProduct, 1);
                //Act
                cartItem.Product = (expected);
                var actual = cartItem.Product;
                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The product that was returned was not correct.");
            }
        }

        [Fact]
        public void GetSetQuantity_ShouldSetAndReturnCorrectQuantity()
        {
            try
            {
                //Assemble
                var expected = 10;
                var cartItem = new StoreItem(new Product(), 2);
                //Act
                cartItem.Quantity = (expected);
                var actual = cartItem.Quantity;

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The quantity that was returned was not correct.");
            }
        }

        [Fact]
        public void GetTotal_ShouldNotExist()
        {
            try
            {
                //Assemble
                var storeItem = new StoreItem(new Product(), 0);
                var type = storeItem.GetType();
                //Act

                //Assert
                Assert.Null(type.GetMethod("GetTotal"));
            }
            catch
            {
                throw new XunitException("The method was found. Should not be there.");
            }
        }
    }
}
