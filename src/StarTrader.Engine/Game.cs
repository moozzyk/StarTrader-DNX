using System;
using System.Collections.Generic;

namespace StarTrader.Engine
{
    public class Game
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Name { get; set; }
        public GameStatus Status { get; set; }
        public int Turn {get; set; } = -1;
        public ICollection<Player> Players { get; set; }
        public Universe Universe {get; set;}
    }
}