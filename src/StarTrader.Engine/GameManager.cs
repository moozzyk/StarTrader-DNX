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

        public void CreateGame(int ownerId, string name)
        {
            _ctx.Add(new Game{ Name = name, OwnerId = ownerId, Status = GameStatus.New });
            _ctx.SaveChanges();
        }

        public IEnumerable<Game> GetGames()
        {
            return _ctx.Games;
        }
    }
}
