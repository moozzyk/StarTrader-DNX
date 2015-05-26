namespace StarTrader.Engine
{
    public class StarSystem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SpacePortClass { get; set; }

        public int LawLevel { get; set; }

        public int PatrolRating { get; set; }

        public int SecurityRating { get; set; }

        public bool HasSafeBerth { get; set; }

        public bool HasShipyard { get; set; }
    }
}