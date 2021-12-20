using System.Text.RegularExpressions;

namespace AoC2021.Day19
{
    public readonly struct Vector
    {
        public int X { get; init; }
        public int Y { get; init; }
        public int Z { get; init; }

        public Vector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        static readonly Regex Matcher = new(@"^(-?\d+),(-?\d+),(-?\d+)$");

        public static Vector Parse(string input)
        {
            var match = Matcher.Match(input);
            if (!match.Success)
            {
                throw new FormatException();
            }

            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);
            var z = int.Parse(match.Groups[3].Value);
            return new Vector(x, y, z);
        }

        public double DistanceTo(Vector other)
        {
            var dx = other.X - X;
            var dy = other.Y - Y;
            var dz = other.Z - Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public int ManhattanDistanceTo(Vector other)
        {
            var dx = Math.Abs(other.X - X);
            var dy = Math.Abs(other.Y - Y);
            var dz = Math.Abs(other.Z - Z);
            return dx + dy + dz;
        }

        public static Vector operator -(Vector v)
            => new Vector(-v.X, -v.Y, -v.Z);

        public static Vector operator +(Vector v1, Vector v2)
            => new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        public static Vector operator -(Vector v1, Vector v2)
            => v1 + -v2;

        public static Vector operator *(Matrix m, Vector v)
        {
            if (m.Width != 3 || m.Height != 3)
            {
                throw new InvalidOperationException();
            }

            var x = m[0, 0] * v.X + m[1, 0] * v.Y + m[2, 0] * v.Z;
            var y = m[0, 1] * v.X + m[1, 1] * v.Y + m[2, 1] * v.Z;
            var z = m[0, 2] * v.X + m[1, 2] * v.Y + m[2, 2] * v.Z;
            return new Vector(x, y, z);
        }

        public override string ToString()
        {
            return $"{X},{Y},{Z}";
        }
    }
}
