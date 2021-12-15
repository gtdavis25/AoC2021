namespace AoC2021.Day15
{
    public class Location
    {
        public int X { get; }
        public int Y { get; }
        public int Risk { get; }
        private List<Location> _neighbours = new();
        public IReadOnlyList<Location> Neighbours => _neighbours.AsReadOnly();

        public Location(int x, int y, int risk)
        {
            X = x;
            Y = y;
            Risk = risk;
        }

        public void Join(Location other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            _neighbours.Add(other);
            other._neighbours.Add(this);
        }

        public IEnumerable<Path> GetShortestPaths()
        {
            var initialPath = new Path(this);
            var paths = new PriorityQueue<Path, int>();
            paths.Enqueue(initialPath, 0);
            var visited = new HashSet<Location>();
            while (paths.Count > 0)
            {
                var currentPath = paths.Dequeue();
                if (visited.Contains(currentPath.End))
                {
                    continue;
                }

                visited.Add(currentPath.End);
                foreach (var neighbour in currentPath.End.Neighbours)
                {
                    if (visited.Contains(neighbour))
                    {
                        continue;
                    }

                    var nextPath = new Path(currentPath, neighbour);
                    paths.Enqueue(nextPath, nextPath.TotalRisk);
                }

                yield return currentPath;
            }
        }
    }
}
