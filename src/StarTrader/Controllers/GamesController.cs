using Microsoft.AspNet.Mvc;
using StarTrader.Models;
using StarTrader.Engine;
using StarTrader.Engine.Model;
using System.Collections.Generic;
using System.Linq;

namespace StarTrader.Controllers
{
    public class GamesController : Controller
    {
        private readonly StarTraderContext _ctx;

        public GamesController(StarTraderContext ctx)
        {
            _ctx = ctx;
        }

        public ActionResult Index()
        {
            return View(new GamesModel(_ctx.Games.Include(g => g.Players).ToList()));
        }

        [HttpPost]
        public ActionResult NewGame(GamesModel gamesModel)
        {
            new GameManager(_ctx)
            .CreateGame(42, gamesModel.NewGameName);

            return Redirect("/Games/Index");
        }
    }
}