using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using ShoppingCartService.BusinessLogic;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Mapping;
using ShoppingCartService.Models;
using ShoppingCartServiceTests.Helpers;
using Xunit;

namespace ShoppingCartServiceTests
{
    public class CheckOutEngineTest
    {
        private readonly IShippingCalculator _shippingCalculator;
        private IMapper _mapper;
        private readonly ICheckOutEngine _sut;

        public CheckOutEngineTest()
        {
            var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });

            _mapper = new Mapper(mapperConfig);
            _shippingCalculator = new ShippingCalculator();
            _sut = new CheckOutEngine(_shippingCalculator, _mapper);
        }

        [Fact]
        public void Total_Cost_With_Customer_Discount()
        {
            // Arrange
            const CustomerType customerType = CustomerType.Premium;
            const ShippingMethod shippingMethod = ShippingMethod.Standard;
            var items = new List<Item>
            {
                ItemDataFixture.Create_By_Price_And_Quantity(2.5, 1),
                ItemDataFixture.Create_By_Price_And_Quantity(3, 2),
                ItemDataFixture.Create_By_Price_And_Quantity(11.5, 4)
            };
            var cart = CartDataFixture.Cart_With_Travel_Cost_Same_Country(customerType,
                                                                          shippingMethod,
                                                                          items);

            // Act
            var result = _sut.CalculateTotals(cart);

            // Assert
            const double totalExpect = 61.65;
            const double customerDiscountExpect = 10.0;
            result.Total.Should().Be(totalExpect);
            result.CustomerDiscount.Should().Be(customerDiscountExpect);
        }

        [Fact]
        public void Total_Cost_Without_Customer_Discount()
        {
            // Arrange
            const CustomerType customerType = CustomerType.Standard;
            const ShippingMethod shippingMethod = ShippingMethod.Standard;
            var items = new List<Item>
            {
                ItemDataFixture.Create_By_Price_And_Quantity(4, 2),
                ItemDataFixture.Create_By_Price_And_Quantity(2, 4),
                ItemDataFixture.Create_By_Price_And_Quantity(8.5, 3)
            };
            var cart = CartDataFixture.Cart_With_Travel_Cost_Same_Country(customerType,
                                                                          shippingMethod,
                                                                          items);

            // Act
            var result = _sut.CalculateTotals(cart);

            // Assert
            const double totalExpect = 59.5;
            const double customerDiscountExpect = 0;
            result.Total.Should().Be(totalExpect);
            result.CustomerDiscount.Should().Be(customerDiscountExpect);
        }
    }
}
