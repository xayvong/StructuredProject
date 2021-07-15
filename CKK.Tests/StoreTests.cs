using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace CKK.Tests
{
    public class StoreTests
    {
        [Fact]
        public void GetSetId_ShouldSetAndReturnCorrectId()
        {
            try
            {
                //Assemble
                Store store = new();
                int expected = 12345;
                //Act
                store.Id = (expected);
                int actual = store.Id;
                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Correct Id Was not given.");
            }
        }

        [Fact]
        public void GetSetName_ShouldSetAndReturnCorrectName()
        {
            try
            {
                //Assemble
                Store store = new();
                var expected = "John Doe";

                //Act
                store.Name =(expected);
                var actual = store.Name;

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Correct Name was not given.");
            }
        }

        [Fact]
        public void AddStoreItem_InvalidValueGiven()
        {
            try
            {
                //Assemble
                Store store = new();
                try
                {
                    var expected = store.AddStoreItem(new Product(), -2);
                }
                catch { }
                //Act

                //Assert
                //I know I am testing two things, but it is really the same thing?
                Assert.Empty(store.GetStoreItems());
            }
            catch
            {
                throw new XunitException("The Store Items were populated incorrectly.");
            }
        }

        [Fact]
        public void AddStoreItem_ShouldAddNewItem()
        {
            try
            {
                //Assemble
                Store store = new();
                var product = new Product();
                product.Id = (1);
                var expected = store.AddStoreItem(product, 5);
                //Act

                //Assert
                //I know I am testing two things, but it is really the same thing?
                Assert.Single(store.GetStoreItems());
                Assert.Equal(expected, store.FindStoreItemById(1));
            }
            catch
            {
                throw new XunitException("The product was not added correctly to the List.");
            }
        }

        [Fact]
        public void AddStoreItem_ShouldAddQuantity()
        {
            try
            {
                //Assemble
                Store store = new();
                var product = new Product();
                product.Id = (2);

                //Act
                store.AddStoreItem(product, 5);
                store.AddStoreItem(product, 1);

                var expected = 6;

                var actual = store.FindStoreItemById(2).Quantity;

                //Assert
                Assert.Single(store.GetStoreItems()); //At this point, there should only be one item.
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The product was not added correctly. ");
            }
        }

        [Fact]
        public void AddStoreItem_ShouldAddNewItemWithMultiple()
        {
            try
            {
                //Assemble
                Store store = new();
                var product1 = new Product();
                product1.Id = (1);
                var product2 = new Product();
                product2.Id = (2);

                //Act
                store.AddStoreItem(product1, 3);
                store.AddStoreItem(product2, 9);
                store.AddStoreItem(product1, 3);

                var expected = 6;

                var actual = store.FindStoreItemById(1).Quantity;
                //Assert

                Assert.Collection(store.GetStoreItems(),
                    elem1 => {
                        Assert.Equal(1, elem1.Product.Id);
                    },
                    elem2 =>
                    {
                        Assert.Equal(2, elem2.Product.Id);
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
        public void RemoveStoreItem_ShouldRemoveItemCorrectly()
        {
            try
            {
                //Assemble
                Store store = new();
                var product1 = new Product();
                product1.Id = (1);
                var product2 = new Product();
                product2.Id = (2);
                var product3 = new Product();
                product3.Id = (3);

                store.AddStoreItem(product1, 2);
                store.AddStoreItem(product2, 3);
                store.AddStoreItem(product3, 8);

                //Act
                var actual = store.RemoveStoreItem(3,4);

                //Assert
                Assert.Collection(store.GetStoreItems(),
                    elem1 =>
                    {
                        Assert.Equal(1, elem1.Product.Id);
                        Assert.Equal(2, elem1.Quantity);
                    },
                    elem2 =>
                    {
                        Assert.Equal(2, elem2.Product.Id);
                        Assert.Equal(3, elem2.Quantity);
                    },
                    elem3 =>
                    {
                        Assert.Equal(3, elem3.Product.Id);
                        Assert.Equal(4, elem3.Quantity);
                    });
                Assert.Equal(store.FindStoreItemById(3), actual);
            }
            catch
            {
                throw new XunitException("The item was not removed correctly");
            }
        }

        [Fact]
        public void RemoveStoreItem_ShouldKeepEmtpyStoreItem()
        {
            try
            {
                //Assemble
                Store store = new();
                var product1 = new Product();
                product1.Id = (1);
                var product2 = new Product();
                product2.Id = (2);
                var product3 = new Product();
                product3.Id = (3);

                store.AddStoreItem(product1, 2);
                store.AddStoreItem(product2, 3);
                store.AddStoreItem(product3, 8);

                //Act
                var actual = store.RemoveStoreItem(3, 8);

                //Assert
                Assert.Collection(store.GetStoreItems(),
                    elem1 =>
                    {
                        Assert.Equal(1, elem1.Product.Id);
                        Assert.Equal(2, elem1.Quantity);
                    },
                    elem2 =>
                    {
                        Assert.Equal(2, elem2.Product.Id);
                        Assert.Equal(3, elem2.Quantity);
                    },
                    elem3 =>
                    {
                        Assert.Equal(3, elem3.Product.Id);
                        Assert.Equal(0, elem3.Quantity);
                    });
                Assert.Equal(store.FindStoreItemById(3), actual);
            }
            catch
            {
                throw new XunitException("The item was not removed correctly");
            }
        }

        [Fact]
        public void RemoveStoreItem_ShouldMakeStoreItemQuantityZero()
        {
            try
            {
                //Assemble
                Store store = new();
                var product1 = new Product();
                product1.Id = (1);
                var product2 = new Product();
                product2.Id = (2);
                var product3 = new Product();
                product3.Id = (3);

                store.AddStoreItem(product1, 2);
                store.AddStoreItem(product2, 3);
                store.AddStoreItem(product3, 8);

                //Act
                var actual = store.RemoveStoreItem(3, 18);

                //Assert
                Assert.Collection(store.GetStoreItems(),
                    elem1 =>
                    {
                        Assert.Equal(1, elem1.Product.Id);
                        Assert.Equal(2, elem1.Quantity);
                    },
                    elem2 =>
                    {
                        Assert.Equal(2, elem2.Product.Id);
                        Assert.Equal(3, elem2.Quantity);
                    },
                    elem3 =>
                    {
                        Assert.Equal(3, elem3.Product.Id);
                        Assert.Equal(0, elem3.Quantity);
                    });
                Assert.Equal(store.FindStoreItemById(3), actual);
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
                Store store = new();
                var product1 = new Product();
                product1.Id = (1);
                var product2 = new Product();
                product2.Id = (2);

                store.AddStoreItem(product1, 3);
                var expected = store.AddStoreItem(product2, 5);
                

                //Act
                var actual = store.FindStoreItemById(2);

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
                Store store = new();
                var product1 = new Product();
                product1.Id = (100);
                //Act
                store.AddStoreItem(product1, 40);

                //Assert
                Assert.Null(store.FindStoreItemById(1));
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
                Store store = new();
                var product1 = new Product();
                product1.Id = (100);
                //Act
                store.AddStoreItem(product1, 40);
                store.RemoveStoreItem(100, 50);

                //Assert
                Assert.NotNull(store.FindStoreItemById(100));
            }
            catch
            {
                throw new XunitException("Was expecting a quantity 0 on an item and it was not returned correctly");
            }
        }
    }
}
