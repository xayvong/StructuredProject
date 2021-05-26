using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace CKK.Tests
{
    public class InheritanceTests
    {
        [Fact]
        public void Entity_EnsureIsAbstract()
        {
            //Assemble

            //Act

            //Assert
            try
            {
                Assert.True(typeof(Entity).IsAbstract);
            }catch
            {
                throw new XunitException("Entity is not Abstract!");
            }
        }
        [Fact]
        public void InventoryItem_EnsureIsAbstract()
        {
            //Assemble

            //Act

            //Assert
            try { 
                Assert.True(typeof(InventoryItem).IsAbstract);
            }
            catch
            {
                throw new XunitException("InventoryItem is not Abstract!");
            }
        }
        [Fact]
        public void Customer_EnsureItIsEntity()
        {
            //Assemble

            //Act

            //Assert 
            try { 
                Assert.IsAssignableFrom<Entity>(new Customer());
            }
            catch
            {
                throw new XunitException("Customer does not inherit from Entity");
            }
        }

        [Fact]
        public void Product_EnsureItIsEntity()
        {
            //Assemble

            //Act

            //Assert
            try
            {
                Assert.IsAssignableFrom<Entity>(new Product());
            }
            catch
            {
                throw new XunitException("Product does not inherit from Entity");
            }
        }

        [Fact]
        public void Store_EnsureIsEntity()
        {
            //Assemble

            //Act

            //Assert
            try { 
                Assert.IsAssignableFrom<Entity>(new Store());
            }
            catch
            {
                throw new XunitException("Store does not inherit from Entity");
            }
        }

        [Fact]
        public void StoreItem_EnsureIsInventoryItem()
        {
            //Assemble

            //Act

            //Assert
            try { 
                Assert.IsAssignableFrom<InventoryItem>(new StoreItem(new Product(),1));
            }
            catch
            {
                throw new XunitException("StoreItem does not inherit from InventoryItem");
            }
        }

        [Fact]
        public void ShoppingCartItem_EnsureIsInventoryItem()
        {
            //Assemble

            //Act

            //Assert
            try {
                Assert.IsAssignableFrom<InventoryItem>(new ShoppingCartItem(new Product(), 1));
            }
            catch
            {
                throw new XunitException("ShoppingCartItem does not inherit from InventoryItem");
            }
        }
    }
}
