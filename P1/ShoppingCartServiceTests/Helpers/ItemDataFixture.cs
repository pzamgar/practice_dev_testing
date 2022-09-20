using AutoFixture;
using ShoppingCartService.DataAccess.Entities;
using ShoppingCartServiceTests.Builders;

namespace ShoppingCartServiceTests.Helpers
{
    public static class ItemDataFixture
    {
        public static Item Create_By_Quantity(uint quantity)
        {
            var fixture = new Fixture();
            
            return new ItemBuilder()
                   .WithProductId(fixture.Create<string>())
                   .WithProductName(fixture.Create<string>())
                   .WithPrice(fixture.Create<double>())
                   .WithQuantity(quantity)
                   .Build();
        }

        public static Item Create_By_Price_And_Quantity(double price, uint quantity)
        {
            var fixture = new Fixture();
            
            return new ItemBuilder()
                   .WithProductId(fixture.Create<string>())
                   .WithProductName(fixture.Create<string>())
                   .WithPrice(price)
                   .WithQuantity(quantity)
                   .Build();
        }
    }
}
