namespace AoC2021.Day12
{
    public class Route
    {
        public List<Cave> Caves { get; }

        public Cave End => Caves.Last();

        public int Revisits
        {
            get
            {
                var seen = new HashSet<Cave>();
                var revisits = 0;
                foreach (var cave in Caves)
                {
                    if (cave.IsSmall && seen.Contains(cave))
                    {
                        revisits++;
                    }

                    seen.Add(cave);
                }

                return revisits;
            }
        }

        public Route(Cave start)
        {
            Caves = new List<Cave> { start };
        }

        public Route(Route routeSoFar, Cave next)
        {
            Caves = routeSoFar.Caves.Append(next).ToList();
        }

        public bool HasVisited(Cave cave) => Caves.Contains(cave);
    }
}
