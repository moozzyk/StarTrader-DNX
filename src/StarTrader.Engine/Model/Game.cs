using System;
using System.Collections.Generic;

namespace StarTrader.Engine.Model
{
	public class Game
	{
		public int Id { get; set; }
		public int OwnerId { get; set; }
        public DateTimeOffset Created { get; set; }
		public string Name { get; set; }
		public GameStatus Status { get; set; }
		
		public ICollection<Player> Players { get; set; }
	}
}