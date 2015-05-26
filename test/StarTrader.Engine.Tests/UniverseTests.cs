using Xunit;
using System.Linq;

namespace StarTrader.Engine
{
    public class UniverseTests
    {
        [Fact]
        public void Create_creates_universe()
        {
            var universe = Universe.Create();
            Assert.NotNull(universe);
            Assert.Equal(6, universe.StarSystems.Count());

            AssertStarSystem(universe.StarSystems.SingleOrDefault(s => s.Name == "Beta Hydri"), spacePortClass: 4,
                lawLevel: 4, patrolRating: 8, securityRating: 10, hasSafeBerth: true, hasShipyard: true);

            AssertStarSystem(universe.StarSystems.SingleOrDefault(s => s.Name == "Sigma Draconis"), spacePortClass: 1,
                lawLevel: 1, patrolRating: 2, securityRating: 4, hasSafeBerth: false, hasShipyard: false);

            AssertStarSystem(universe.StarSystems.SingleOrDefault(s => s.Name == "Mu Herculis"), spacePortClass: 0,
                lawLevel: 1, patrolRating: 0, securityRating: 3, hasSafeBerth: false, hasShipyard: false);

            AssertStarSystem(universe.StarSystems.SingleOrDefault(s => s.Name == "Tau Ceti"), spacePortClass: 3,
                lawLevel: 2, patrolRating: 5, securityRating: 7, hasSafeBerth: true, hasShipyard: true);

            AssertStarSystem(universe.StarSystems.SingleOrDefault(s => s.Name == "Epsilon Eridani"), spacePortClass: 3,
                lawLevel: 4, patrolRating: 7, securityRating: 9, hasSafeBerth: true, hasShipyard: true);

            AssertStarSystem(universe.StarSystems.SingleOrDefault(s => s.Name == "Gamma Leporis"), spacePortClass: 1,
                lawLevel: 3, patrolRating: 4, securityRating: 6, hasSafeBerth: true, hasShipyard: false);
        }

        private void AssertStarSystem(StarSystem s, int spacePortClass, int lawLevel, int patrolRating,
            int securityRating, bool hasSafeBerth, bool hasShipyard)
        {
            Assert.NotNull(s);
            Assert.Equal(spacePortClass, s.SpacePortClass);
            Assert.Equal(lawLevel, s.LawLevel);
            Assert.Equal(patrolRating, s.PatrolRating);
            Assert.Equal(securityRating, s.SecurityRating);
            Assert.Equal(hasSafeBerth, s.HasSafeBerth);
            Assert.Equal(hasShipyard, s.HasShipyard);
        }
    }
}