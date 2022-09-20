using System.Collections.Generic;
using AutoFixture;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartService.Models;

namespace ShoppingCartServiceTests.Builders
{
    public class CartBuilder : BuilderFixture
    {
        private string _id;
        private string _customerId;
        private CustomerType _customerType;
        private ShippingMethod _shippingMethod;
        private Address _shippingAddress;
        private List<Item> _items;

        public CartBuilder()
        {
            _id = _fixture.Create<string>();
            _customerId = _fixture.Create<string>();
            _items = new List<Item>();
        }

        public CartBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public CartBuilder WithCustomerId(string customerId)
        {
            _customerId = customerId;
            return this;
        }

        public CartBuilder WithCustomerType(CustomerType customerType)
        {
            _customerType = customerType;
            return this;
        }

        public CartBuilder WithShippingMethod(ShippingMethod shippingMethod)
        {
            _shippingMethod = shippingMethod;
            return this;
        }

        public CartBuilder WithShippingAddress(Address shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        public CartBuilder WithItems(List<Item> items)
        {
            _items = items;
            return this;
        }
        
        public Cart Build()
        {
            return new Cart
            {
                Id = _id,
                CustomerId = _customerId,
                CustomerType = _customerType,
                ShippingMethod = _shippingMethod,
                ShippingAddress = _shippingAddress,
                Items = _items
            };
        }
    }
}
