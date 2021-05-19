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
                customer.SetId(expected);
                int actual = customer.GetId();
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
                customer.SetName(expected);
                var actual = customer.GetName();

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
                customer.SetAddress(expected);
                var actual = customer.GetAddress();

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
