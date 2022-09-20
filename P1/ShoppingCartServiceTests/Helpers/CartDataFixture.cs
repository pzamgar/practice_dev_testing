using System.Collections.Generic;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Models;
using ShoppingCartServiceTests.Builders;

namespace ShoppingCartServiceTests.Helpers
{
    public static class CartDataFixture
    {
        public static Cart Cart_Without_Items()
        {
            var address = AddressDataFixture.Address_In_Same_Country();

            return new CartBuilder()
                   .WithCustomerType(CustomerType.Standard)
                   .WithShippingMethod(ShippingMethod.Standard)
                   .WithShippingAddress(address)
                   .Build();
        }

        public static Cart Cart_With_Travel_Cost_Same_Country(CustomerType customerType, ShippingMethod shippingMethod, List<Item> items)
        {
            var address = AddressDataFixture.Address_In_Same_Country();

            return new CartBuilder()
                   .WithCustomerType(customerType)
                   .WithShippingMethod(shippingMethod)
                   .WithShippingAddress(address)
                   .WithItems(items)
                   .Build();
        }

        public static Cart Cart_With_Travel_Cost_Same_City(CustomerType customerType, ShippingMethod shippingMethod, List<Item> items)
        {
            var address = AddressDataFixture.Address_In_Same_City();

            return new CartBuilder()
                   .WithCustomerType(customerType)
                   .WithShippingMethod(shippingMethod)
                   .WithShippingAddress(address)
                   .WithItems(items)
                   .Build();
        }

        public static Cart Cart_With_Travel_Cost_International(CustomerType customerType, ShippingMethod shippingMethod, List<Item> items)
        {
            var address = AddressDataFixture.Address_International_Country();

            return new CartBuilder()
                   .WithCustomerType(customerType)
                   .WithShippingMethod(shippingMethod)
                   .WithShippingAddress(address)
                   .WithItems(items)
                   .Build();
        }
    }
}
