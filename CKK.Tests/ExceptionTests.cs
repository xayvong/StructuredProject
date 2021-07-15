using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace CKK.Tests
{
    public class ExceptionTests
    {
        [Fact]
        public void Entity_ThrowsInvalidId()
        {
            try
            {
                //Asssemble
                Entity entity = new Product();
                //Act

                //Assert
                Assert.Throws<InvalidIdException>(() => entity.Id = (-1));
            }
            catch
            {
                throw new XunitException("The Id =  method did not throw an exception when it should have.");
            }
        }

        [Fact]
        public void InventoryItem_ThrowsWithInvalidQuantity()
        {
            try
            {
                //Assemble
                InventoryItem item = new ShoppingCartItem(new Product(), 4);
                //Act

                //Assert
                Assert.Throws<InventoryItemStockTooLowException>(() => item.Quantity = (-1));
            }
            catch
            {
                throw new XunitException("The Quantity =  method did not throw an exception when it should have.");
            }
        }

        [Fact]
        public void Product_ThrowsWithInvalidPrice()
        {
            try
            {
                //Assemble
                var prod = new Product();
                //Act

                //Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => prod.Price = (-10.509m));
            }
            catch
            {
                throw new XunitException("The Price =  method did not throw an exception when it should have.");
            }
        }

        [Fact]
        public void ShoppingCart_AddProduct_ShouldThrowInvalidQuantity()
        {
            try
            {
                //Assemble
                ShoppingCart cart = new ShoppingCart(new Customer());

                //Act

                //Assert
                Assert.Throws<InventoryItemStockTooLowException>(() => cart.AddProduct(new Product(), -1));

            }
            catch
            {
                throw new XunitException("AddProduct did not throw and exception when it should have");
            }
        }

        [Fact]
        public void ShoppingCart_RemoveProduct_ShouldThrowIfDoesntExist()
        {
            try
            {
                //Assemble
                ShoppingCart cart = new ShoppingCart(new Customer());
                //Act

                //Assert
                Assert.Throws<ProductDoesNotExistException>(() => cart.RemoveProduct(1, 1));
            }
            catch
            {
                throw new XunitException("RemoveProduct did not throw exception when it should have");
            }
        }

        [Fact]
        public void Store_AddStoreItem_ThrowsWithIncorrectQuantity()
        {
            try
            {
                //Assemble
                Store store = new Store();
                //Act

                //Assert
                Assert.Throws<InventoryItemStockTooLowException>(() => store.AddStoreItem(new Product(), -5));
            }
            catch
            {
                throw new XunitException("AddStoreItem did not throw exception when it should have");
            }
        }

        [Fact]
        public void Store_RemoveItem_ThrowsIfItemNotFound()
        {
            try
            {
                //Assemble
                Store s = new Store();
                //Act

                //Assert
                Assert.Throws<ProductDoesNotExistException>(() => s.RemoveStoreItem(1, 1));
            }
            catch
            {
                throw new XunitException("RemoveItem did not throw exception when it should have");
            }
        }

        [Fact]
        public void Store_RemoveItem_ThrowsIfInvalidQuantity()
        {
            try
            {
                //Assemble
                Store s = new();
                //Act
                Product p = new();
                p.Id = 1;
                s.AddStoreItem(p, 14);
                //Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => s.RemoveStoreItem(1, -1));
            }
            catch
            {
                throw new XunitException("RemoveItem did not throw exception when it should have");
            }
        }

        [Fact]
        public void ShoppingCart_RemoveItem_ThrowsIfInvalidQuantity()
        {
            try
            {
                //Assemble
                ShoppingCart cart = new ShoppingCart(new Customer());
                //Act
                Product p = new();
                p.Id = 1;
                cart.AddProduct(p, 2);

                //Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => cart.RemoveProduct(1, -4));
            }
            catch
            {
                throw new XunitException("RemoveItem did not throw exception when it should have");
            }
        }
        [Fact]
        public void ShoppingCart_FindById_ThrowsInvalidId()
        {
            try
            {
                //Assemble
                ShoppingCart cart = new ShoppingCart(new Customer());

                //Act

                //Assert
                Assert.Throws<InvalidIdException>(() => cart.GetProductById(-1));
            }
            catch
            {
                throw new XunitException("FindById did not throw exception when it should have");
            }
        }

        [Fact]
        public void Store_FindById_ThrowsInvalidId()
        {
            try
            {
                //Assemble
                Store s = new();
                //Act

                //Assert
                Assert.Throws<InvalidIdException>(() => s.FindStoreItemById(-1));
            }
            catch
            {
                throw new XunitException("FindById did not throw exception when it should have");
            }
        }
    }
}
