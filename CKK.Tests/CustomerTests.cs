using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace CKK.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void GetSetId_ShouldSetAndReturnCorrectId()
        {
            try
            {
                //Assemble
                Customer customer = new Customer();
                int expected = 12345;
                //Act
                customer.Id = (expected);
                int actual = customer.Id;
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
                Customer customer = new Customer();
                var expected = "John Doe";

                //Act
                customer.Name =(expected);
                var actual = customer.Name;

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Correct Name was not given");
            }
        }

        [Fact]
        public void GetSetAddress_ShouldSetAndReturnCorrectAddress()
        {
            try
            {
                //Assemble
                Customer customer = new Customer();
                var expected = "1234 Number Street";

                //Act
                customer.Address = (expected);
                var actual = customer.Address;

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Correct Address was not given");
            }
        }
    }
}
