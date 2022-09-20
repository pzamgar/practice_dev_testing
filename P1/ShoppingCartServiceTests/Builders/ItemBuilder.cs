using AutoFixture;
using ShoppingCartService.DataAccess.Entities;

namespace ShoppingCartServiceTests.Builders
{
    public class ItemBuilder : BuilderFixture
    {
        private string _productId;
        private string _productName;
        private double _price;
        private uint _quantity;

        public ItemBuilder()
        {
            _productId = _fixture.Create<string>();
        }

        public ItemBuilder WithProductId(string productId)
        {
            _productId = productId;
            return this;
        }

        public ItemBuilder WithProductName(string productName)
        {
            _productName = productName;
            return this;
        }

        public ItemBuilder WithPrice(double price)
        {
            _price = price;
            return this;
        }

        public ItemBuilder WithQuantity(uint quantity)
        {
            _quantity = quantity;
            return this;
        }

        public Item Build()
        {
            return new Item
            {
                ProductId = _productId,
                ProductName = _productName,
                Price = _price,
                Quantity = _quantity
            };
        }
    }
}
