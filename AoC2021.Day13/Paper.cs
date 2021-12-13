namespace AoC2021.Day13
{
    public class Paper
    {
        public List<Point> Dots { get; set; }

        public int Width => Dots.Max(p => p.X) + 1;
        public int Height => Dots.Max(p => p.Y) + 1;

        public Paper(IEnumerable<Point> dots)
        {
            Dots = dots.ToList();
        }

        public void ApplyFold(Fold fold)
        {
            switch (fold.Direction)
            {
                case FoldDirection.X:
                    Dots = Dots
                        .Select(p => p.X <= fold.Offset ? p : p with { X = 2 * fold.Offset - p.X })
                        .Distinct()
                        .ToList();
                    break;

                case FoldDirection.Y:
                    Dots = Dots
                        .Select(p => p.Y <= fold.Offset ? p : p with { Y = 2 * fold.Offset - p.Y })
                        .Distinct()
                        .ToList();
                    break;

                default:
                    throw new Exception($"Invalid fold direction: {fold.Direction}");
            }
        }

        public override string ToString()
        {
            var rows = new char[Height][];
            var width = Width;
            for (int y = 0; y < rows.Length; y++)
            {
                rows[y] = Enumerable.Repeat('.', width).ToArray();
            }

            foreach (var p in Dots)
            {
                rows[p.Y][p.X] = '#';
            }

            return string.Join(Environment.NewLine, rows.Select(row => new string(row)));
        }
    }
}
