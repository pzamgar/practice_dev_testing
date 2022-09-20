using AutoFixture;

namespace ShoppingCartServiceTests.Builders
{
    public abstract class BuilderFixture
    {
        protected Fixture _fixture;

        protected BuilderFixture()
        {
            _fixture = new Fixture();
        }
    }
}
