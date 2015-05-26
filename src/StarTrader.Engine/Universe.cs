using System.Collections.Generic;

namespace StarTrader.Engine
{
    public class Universe
    {
        public int Id {get; set; }

        public ICollection<StarSystem> StarSystems {get; set;}

        public static Universe Create()
        {
            return new Universe
            {
                StarSystems = new List<StarSystem>
                {
                    new StarSystem { Name = "Beta Hydri", SpacePortClass = 4, LawLevel = 4, PatrolRating = 8, SecurityRating = 10,
                        HasSafeBerth = true, HasShipyard = true },
                    new StarSystem { Name = "Sigma Draconis", SpacePortClass = 1, LawLevel = 1, PatrolRating = 2, SecurityRating = 4,
                        HasSafeBerth = false, HasShipyard = false },
                    new StarSystem { Name = "Mu Herculis", SpacePortClass = 0, LawLevel = 1, PatrolRating = 0, SecurityRating = 3,
                        HasSafeBerth = false, HasShipyard = false },
                    new StarSystem { Name = "Tau Ceti", SpacePortClass = 3, LawLevel = 2, PatrolRating = 5, SecurityRating = 7,
                        HasSafeBerth = true, HasShipyard = true },
                    new StarSystem { Name = "Epsilon Eridani", SpacePortClass = 3, LawLevel = 4, PatrolRating = 7, SecurityRating = 9,
                        HasSafeBerth = true, HasShipyard = true },
                    new StarSystem { Name = "Gamma Leporis", SpacePortClass = 1, LawLevel = 3, PatrolRating = 4, SecurityRating = 6,
                        HasSafeBerth = true, HasShipyard = false },
                }
            };
        }
    }
}