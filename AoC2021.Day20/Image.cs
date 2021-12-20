using System.Text;

namespace AoC2021.Day20
{
    public class Image
    {
        private HashSet<Point> _points = new();

        private int minX;
        private int minY;
        private int maxX;
        private int maxY;

        public int MinX => minX;
        public int MaxX => maxX;
        public int MinY => minY;
        public int MaxY => maxY;

        public int LitCount
        {
            get
            {
                var count = 0;
                for (int y = MinY; y <= MaxY; y++)
                {
                    for (int x = MinX; x <= MaxX; x++)
                    {
                        if (IsLit(x, y))
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
        }

        public bool Inverted { get; }

        public Image(bool invert)
        {
            Inverted = invert;
        }

        public bool IsLit(int x, int y)
        {
            return Inverted ^ _points.Contains(new Point(x, y));
        }

        public void SetPixel(int x, int y, bool lit)
        {
            if (Inverted ^ lit)
            {
                _points.Add(new Point(x, y));
                minX = Math.Min(x, minX);
                maxX = Math.Max(x, maxX);
                minY = Math.Min(y, minY);
                maxY = Math.Max(y, maxY);
            }
        }

        public override string ToString()
        {
            var lines = new List<string>();
            var builder = new StringBuilder();
            for (int y = minY; y <= maxY; y++)
            {
                builder.Clear();
                for (int x = minX; x <= maxX; x++)
                {
                    builder.Append(IsLit(x, y) ? '#' : '.');
                }

                lines.Add(builder.ToString());
            }

            return string.Join(Environment.NewLine, lines);
        }
    }
}
