using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace CKK.Tests
{
    public class ProductTests
    {
        [Fact]
        public void GetSetId_ShouldSetAndReturnCorrectId()
        {
            try
            {
                //Assemble
                Product product = new Product();
                int expected = 12345;
                //Act
                product.Id = (expected);
                int actual = product.Id;
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
                Product product = new Product();
                var expected = "John Doe";

                //Act
                product.Name =(expected);
                var actual = product.Name;

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Correct Name was not given.");
            }
        }

        [Fact]
        public void GetSetAddress_ShouldSetAndReturnCorrectPrice()
        {
            try
            {
                //Assemble
                Product product = new Product();
                var expected = 1234.56754m;

                //Act
                product.Price = (expected);
                var actual = product.Price;

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Correct Price was not given.");
            }
        }
    }
}
