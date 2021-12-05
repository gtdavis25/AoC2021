using System.Text.RegularExpressions;

namespace AoC2021.Day5
{
    public struct LineSegment
    {
        public Point P1 { get; set; }
        public Point P2 { get; set; }

        public int MinX => P1.X < P2.X ? P1.X : P2.X;
        public int MaxX => P1.X < P2.X ? P2.X : P1.X;
        public int MinY => P1.Y < P2.Y ? P1.Y : P2.Y;
        public int MaxY => P1.Y < P2.Y ? P2.Y : P1.Y;

        public IEnumerable<Point> Points
        {
            get
            {
                var (dx, dy) = GetSlope();
                for (var p = P1; true; p.X += dx, p.Y += dy)
                {
                    yield return p;
                    if (p.Equals(P2))
                    {
                        break;
                    }
                }
            }
        }

        static readonly Regex Matcher = new(@"^(\d+),(\d+) -> (\d+),(\d+)$");

        public static LineSegment Parse(string line)
        {
            if (line is null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            var match = Matcher.Match(line);
            if (!match.Success)
            {
                throw new FormatException();
            }

            var x1 = int.Parse(match.Groups[1].Value);
            var y1 = int.Parse(match.Groups[2].Value);
            var x2 = int.Parse(match.Groups[3].Value);
            var y2 = int.Parse(match.Groups[4].Value);

            return new LineSegment
            {
                P1 = new Point
                {
                    X = x1,
                    Y = y1
                },
                P2 = new Point
                {
                    X = x2,
                    Y = y2
                }
            };
        }

        public (int, int) GetSlope()
        {
            var dx = P2.X - P1.X;
            var dy = P2.Y - P1.Y;
            var gcd = Gcd(dx, dy);
            return (dx / gcd, dy / gcd);
        }

        private int Gcd(int a, int b)
        {
            if (b == 0)
            {
                return Math.Abs(a);
            }

            return Gcd(b, a % b);
        }
    }
}
