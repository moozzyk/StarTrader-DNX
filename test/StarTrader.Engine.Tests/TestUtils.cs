using Microsoft.Data.Entity;

namespace StarTrader.Engine
{
    public class TestUtils
    {
        public static StarTraderContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryStore(persist: true);

            return new StarTraderContext(optionsBuilder.Options);
        }
    }
}
