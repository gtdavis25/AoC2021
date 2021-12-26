namespace AoC2021.Day23
{
    public readonly struct Point
    {
        public int X { get; init; }
        public int Y { get; init; }

        public IEnumerable<Point> AdjacentPoints
        {
            get
            {
                yield return new Point(X, Y - 1);
                yield return new Point(X - 1, Y);
                yield return new Point(X + 1, Y);
                yield return new Point(X, Y + 1);
            }
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
