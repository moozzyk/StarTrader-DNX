using Xunit;
using System.Linq;
using StarTrader.Engine.Model;

namespace StarTrader.Engine
{
    public class GameManagerTests
    {
        [Fact]
        public void Can_create_game()
        {
            using(var ctx = TestUtils.CreateContext())
            {
                var gameManager = new GameManager(ctx);
                gameManager.CreateGame(42, "Test game");
            }

            using(var ctx = TestUtils.CreateContext())
            {
                var gameManager = new GameManager(ctx);
                var game = gameManager.GetGames().SingleOrDefault();

                Assert.NotNull(game);
                Assert.Equal("Test game", game.Name);
                Assert.Equal(42, game.OwnerId);
                Assert.Equal(GameStatus.New, game.Status);
            }
        }
    }
}
