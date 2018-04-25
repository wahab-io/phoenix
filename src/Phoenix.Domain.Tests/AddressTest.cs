using Xunit;
using Phoenix.Domain;

namespace Phoenix.Domain.Tests
{
    public class AddressTest
    {
        [Fact]
        void AddressAreEqual()
        {
            Address address1 = new Address("23 Downing Street", "", "London", "110WL", "England", "United Kingdom");
            Address address2 = new Address("23 Downing Street", "", "London", "110WL", "England", "United Kingdom");
            Assert.Equal<Address>(address1, address2);
        }
    }
}