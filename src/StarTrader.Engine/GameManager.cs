using System;
using System.Linq;
using StarTrader.Engine.Model;
using System.Collections.Generic;

namespace StarTrader.Engine
{
    public class GameManager
    {
        private readonly StarTraderContext _ctx;

        public GameManager(StarTraderContext ctx)
        {
            _ctx = ctx;
        }

        public Game CreateGame(int ownerId, string name)
        {
            var game = _ctx.Add(new Game{ Name = name, OwnerId = ownerId, Status = GameStatus.New });
            _ctx.SaveChanges();

            return game.Entity;
        }

        public IEnumerable<Game> GetGames()
        {
            return _ctx.Games.Include(g => g.Players);
        }

        public void AddPlayer(int gameId, int ownerId, string name)
        {
            var game = _ctx.Games.Include(g => g.Players).SingleOrDefault(e => e.Id == gameId);
            if(game == null)
            {
                throw new ArgumentException("Invalid game identifier", nameof(gameId));
            }

            game.Players.Add(new Player{ OwnerId = ownerId, Name = name});
            _ctx.SaveChanges();
        }
    }
}
