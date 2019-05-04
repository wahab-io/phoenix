using Xunit;
using Phoenix.Domain;

namespace Phoenix.Domain.Tests
{
    public class CustomerTest
    {
        [Fact]
        public void CustomerAreEqual()
        {
            var address = new Address("101 Road", string.Empty, "Columbus",
                                        "10910", "OH", "USA");
            var customer1 = new Customer("Northwind Traders", address);
            var customer2 = customer1;
            Assert.Equal(customer1.Id, customer2.Id);
        }
    }
}