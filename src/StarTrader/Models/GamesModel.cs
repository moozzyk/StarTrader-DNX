using StarTrader.Engine;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarTrader.Models
{
    public class GamesModel
    {
        private readonly IList<Game> _games;

        public GamesModel()
        { }

        public GamesModel(IList<Game> games)
        {
            _games = games;
        }

        public IEnumerable<Game> Games => _games;

        [Required]
        [MinLength(1)]
        public string NewGameName { get; set; }
    }
}