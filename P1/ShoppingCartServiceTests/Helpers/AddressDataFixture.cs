using ShoppingCartService.Models;
using ShoppingCartServiceTests.Builders;

namespace ShoppingCartServiceTests.Helpers
{
    public static class AddressDataFixture
    {
        public static Address Address_In_Same_Country()
        {
            return new AddressBuilder()
                   .WithCountry("USA")
                   .WithCity("Detroit")
                   .WithStreet("1234 college.")
                   .Build();
        }          
        
        public static Address Address_In_Same_City()
        {
            return new AddressBuilder()
                   .WithCountry("USA")
                   .WithCity("Dallas")
                   .WithStreet("1234 place reial.")
                   .Build();
        }        
        
        public static Address Address_International_Country()
        {
            return new AddressBuilder()
                   .WithCountry("GERMANY")
                   .WithCity("Berlin")
                   .WithStreet("1234 point new.")
                   .Build();
        }
    }
}
