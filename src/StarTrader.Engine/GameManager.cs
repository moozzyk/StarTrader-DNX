using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;

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
            var game = _ctx.Add(new Game{ Name = name, OwnerId = ownerId,
                Status = GameStatus.New, Created = DateTimeOffset.Now });
            _ctx.SaveChanges();

            return game.Entity;
        }

        public IEnumerable<Game> GetGames()
        {
            return _ctx.Games.Include(g => g.Players);
        }

        public void AddPlayer(int gameId, int ownerId, string name)
        {
            var game = FindGame(gameId);

            if (game.Status != GameStatus.New)
            {
                throw new InvalidOperationException("Players cannot be added after a game has started.");
            }

            game.Players.Add(new Player{ OwnerId = ownerId, Name = name});
            _ctx.SaveChanges();
        }
        
        public void StartGame(int gameId)
        {
            var game = FindGame(gameId);
            
            if (game.Status != GameStatus.New)
            {
                throw new InvalidOperationException("Cannot start a game that is already in progress or has finished.");
            }

            if (!game.Players.Any())
            {
                throw new InvalidOperationException("Cannot start a game that has no players.");
            }

            game.Status = GameStatus.InProgress;
            game.Turn = 0;
            game.Universe = Universe.Create();
            _ctx.SaveChanges();
        }

        private Game FindGame(int gameId)
        {
            var game = _ctx.Games.Include(g => g.Players).SingleOrDefault(e => e.Id == gameId);
            if (game == null)
            {
                throw new ArgumentException("Invalid game identifier", nameof(gameId));
            }
            
            return game;
        }
    }
}
