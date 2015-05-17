using Microsoft.AspNet.Mvc;
using StarTrader.Engine;
using StarTrader.Engine.Model;
using System.Collections.Generic;

namespace StarTrader.Controllers
{
	public class GameController : Controller
	{
		private readonly StarTraderContext _ctx;

		public GameController(StarTraderContext ctx)
		{
			_ctx = ctx;
		}

        public IEnumerable<Game> Index()
        {
			return _ctx.Games;
        }
	}
}