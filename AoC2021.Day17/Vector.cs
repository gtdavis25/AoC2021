namespace AoC2021.Day17
{
    public readonly struct Vector
    {
        public int X { get; init; }
        public int Y { get; init; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
