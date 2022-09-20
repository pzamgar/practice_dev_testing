using System;
using System.Collections.Generic;
using FluentAssertions;
using ShoppingCartService.BusinessLogic;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Models;
using ShoppingCartServiceTests.Helpers;
using Xunit;

namespace ShoppingCartServiceTests
{
    public class ShippingCalculatorTest
    {
        private readonly IShippingCalculator _sut;

        public ShippingCalculatorTest()
        {
            _sut = new ShippingCalculator();
        }

        // calculate shipping empty cart
        [Fact]
        public void Without_Shipping_Cost_To_Empty_Cart()
        {
            // Arrange
            var cart = CartDataFixture.Cart_Without_Items();

            // Act
            var result = _sut.CalculateShippingCost(cart);

            // Assert
            result.Should().Be(0);
        }

        [Theory]
        [InlineData(CustomerType.Premium, ShippingMethod.Standard, 12)]
        [InlineData(CustomerType.Premium, ShippingMethod.Expedited, 12)]
        [InlineData(CustomerType.Premium, ShippingMethod.Priority, 12)]
        [InlineData(CustomerType.Premium, ShippingMethod.Express, 30)]
        [InlineData(CustomerType.Standard, ShippingMethod.Standard, 12)]
        [InlineData(CustomerType.Standard, ShippingMethod.Expedited, 14.40)]
        [InlineData(CustomerType.Standard, ShippingMethod.Priority, 24)]
        [InlineData(CustomerType.Standard, ShippingMethod.Express, 30)]
        public void Shipping_Cost_With_Travel_Cost_Same_Country(CustomerType customerType,
                                                                ShippingMethod shippingMethod,
                                                                double expectShippingCost)
        {
            // Arrange
            var items = new List<Item>
            {
                ItemDataFixture.Create_By_Quantity(2),
                ItemDataFixture.Create_By_Quantity(1),
                ItemDataFixture.Create_By_Quantity(3)
            };
            var cart = CartDataFixture.Cart_With_Travel_Cost_Same_Country(customerType, shippingMethod, items);

            // Act
            var result = _sut.CalculateShippingCost(cart);
            var resultRound = Math.Round(result, 2, MidpointRounding.ToEven);

            // Assert
            resultRound.Should().Be(expectShippingCost);
        }

        [Theory]
        [InlineData(CustomerType.Premium, ShippingMethod.Standard, 6)]
        [InlineData(CustomerType.Premium, ShippingMethod.Expedited, 6)]
        [InlineData(CustomerType.Premium, ShippingMethod.Priority, 6)]
        [InlineData(CustomerType.Premium, ShippingMethod.Express, 15)]
        [InlineData(CustomerType.Standard, ShippingMethod.Standard, 6)]
        [InlineData(CustomerType.Standard, ShippingMethod.Expedited, 7.20)]
        [InlineData(CustomerType.Standard, ShippingMethod.Priority, 12)]
        [InlineData(CustomerType.Standard, ShippingMethod.Express, 15)]
        public void Shipping_Cost_With_Travel_Cost_Same_City(CustomerType customerType,
                                                             ShippingMethod shippingMethod,
                                                             double expectShippingCost)
        {
            // Arrange
            var items = new List<Item>
            {
                ItemDataFixture.Create_By_Quantity(2),
                ItemDataFixture.Create_By_Quantity(1),
                ItemDataFixture.Create_By_Quantity(3)
            };
            var cart = CartDataFixture.Cart_With_Travel_Cost_Same_City(customerType, shippingMethod, items);

            // Act
            var result = _sut.CalculateShippingCost(cart);
            var resultRound = Math.Round(result, 2, MidpointRounding.ToEven);

            // Assert
            resultRound.Should().Be(expectShippingCost);
        }

        [Theory]
        [InlineData(CustomerType.Premium, ShippingMethod.Standard, 90)]
        [InlineData(CustomerType.Premium, ShippingMethod.Expedited, 90)]
        [InlineData(CustomerType.Premium, ShippingMethod.Priority, 90)]
        [InlineData(CustomerType.Premium, ShippingMethod.Express, 225)]
        [InlineData(CustomerType.Standard, ShippingMethod.Standard, 90)]
        [InlineData(CustomerType.Standard, ShippingMethod.Expedited, 108)]
        [InlineData(CustomerType.Standard, ShippingMethod.Priority, 180)]
        [InlineData(CustomerType.Standard, ShippingMethod.Express, 225)]
        public void Shipping_Cost_With_Travel_Cost_International(CustomerType customerType,
                                                                 ShippingMethod shippingMethod,
                                                                 double expectShippingCost)
        {
            // Arrange
            var items = new List<Item>
            {
                ItemDataFixture.Create_By_Quantity(2),
                ItemDataFixture.Create_By_Quantity(1),
                ItemDataFixture.Create_By_Quantity(3)
            };
            var cart = CartDataFixture.Cart_With_Travel_Cost_International(customerType, shippingMethod, items);

            // Act
            var result = _sut.CalculateShippingCost(cart);
            var resultRound = Math.Round(result, 2, MidpointRounding.ToEven);

            // Assert
            resultRound.Should().Be(expectShippingCost);
        }
    }
}
