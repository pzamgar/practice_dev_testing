using System.Collections.Generic;
using FluentAssertions;
using ShoppingCartService.BusinessLogic.Validation;
using ShoppingCartService.Models;
using Xunit;

namespace ShoppingCartServiceTests
{
    public class AddressValidatorTest
    {
        private readonly AddressValidator _sut;

        public AddressValidatorTest()
        {
            _sut = new AddressValidator();
        }

        [Theory]
        [MemberData(nameof(AddressData.Data), MemberType = typeof(AddressData))]
        public void Shipping_Address_Is_Not_Valid(Address address)
        {
            // Act
            var result = _sut.IsValid(address);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Shipping_Address_Is_Valid()
        {
            // Arrange
            var address = new Address
            {
                Country = "country",
                City = "city",
                Street = "street"
            };

            // Act
            var result = _sut.IsValid(address);

            // Assert
            result.Should().BeTrue();
        }
    }

    public class AddressData
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { new Address { Country = "", City = "city", Street = "street" } },
                new object[] { new Address { Country = "country", City = "", Street = "street" } },
                new object[] { new Address { Country = "country", City = "", Street = "" } },
            };
    }
}
