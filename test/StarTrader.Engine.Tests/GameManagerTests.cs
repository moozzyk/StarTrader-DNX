using StarTrader.Engine;
using Xunit;

namespace StarTrader.Engine.Tests
{
    public class GameManagerTests
    {
        [Fact]
        public void GameTest()
        {
            Assert.True(new GameManager().GetValue());
        }
    }
}
