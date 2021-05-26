using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace CKK.Tests
{
    public class InheritanceTests
    {
        [Fact]
        public void Customer_EnsureItIsEntity()
        {
            //Assemble

            //Act

            //Assert 
            Assert.IsAssignableFrom<Entity>(new Customer());
        }

        [Fact]
        public void Product_EnsureItIsEntity()
        {
            //Assemble

            //Act

            //Assert
            Assert.IsAssignableFrom<Entity>(new Product());
        }

        [Fact]
        public void Store_EnsureIsEntity()
        {
            //Assemble

            //Act

            //Assert
            Assert.IsAssignableFrom<Entity>(new Store());
        }

        [Fact]
        public void StoreItem_EnsureIsInventoryItem()
        {
            //Assemble

            //Act

            //Assert
            Assert.IsAssignableFrom<InventoryItem>(new StoreItem(new Product(),1));
        }

        [Fact]
        public void ShoppingCartItem_EnsureIsInventoryItem()
        {
            //Assemble

            //Act

            //Assert
            Assert.IsAssignableFrom<InventoryItem>(new ShoppingCartItem(new Product(), 1));
        }
    }
}
