using System.Linq;
using Microsoft.Data.Entity;
using Xunit;

namespace StarTrader.Engine
{
    public class GameManagerTests
    {
        [Fact]
        public void Can_create_game()
        {
            int gameId = -1;
            using(var ctx = TestUtils.CreateContext())
            {
                var gameManager = new GameManager(ctx);
                gameId = gameManager.CreateGame(42, "Test game").Id;
            }

            using(var ctx = TestUtils.CreateContext())
            {
                var gameManager = new GameManager(ctx);
                var game = ctx.Games.Single(g => g.Id == gameId);

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
                var game = ctx.Games.Include(g => g.Players).Single(g => g.Id == gameId);

                var player = game.Players.SingleOrDefault();
                Assert.NotNull(player);
                Assert.Equal("Hegemon", player.Name);
                Assert.Equal(42, player.OwnerId);
            }
        }

        [Fact]
        public void Start_game_sets_settings()
        {
            int gameId = -1;

            using(var ctx = TestUtils.CreateContext())
            {
                var gameManager = new GameManager(ctx);
                var game = gameManager.CreateGame(42, "Test game");
                gameId = game.Id;
                gameManager.AddPlayer(game.Id, 42, "Hegemon");
                gameManager.StartGame(game.Id);
            }

            using(var ctx = TestUtils.CreateContext())
            {
                var gameManager = new GameManager(ctx);
                var game = ctx.Games.Include(g => g.Universe).Single(g => g.Id == gameId);
                Assert.Equal(GameStatus.InProgress, game.Status);
                Assert.Equal(0, game.Turn);
                Assert.NotNull(game.Universe);
            }
        }
    }
}
