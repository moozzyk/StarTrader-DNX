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

        [Fact]
        public void Can_add_player()
        {
            int gameId = -1;

            using(var ctx = TestUtils.CreateContext())
            {
                var gameManager = new GameManager(ctx);
                var game = gameManager.CreateGame(42, "Test game");
                gameId = game.Id;
                gameManager.AddPlayer(game.Id, 42, "Hegemon");
            }

            using(var ctx = TestUtils.CreateContext())
            {
                var gameManager = new GameManager(ctx);
                var game = gameManager.GetGames().Single(g => g.Id == gameId);

                var player = game.Players.SingleOrDefault();
                Assert.NotNull(player);
                Assert.Equal("Hegemon", player.Name);
                Assert.Equal(42, player.OwnerId);
            }
        }
    }
}
