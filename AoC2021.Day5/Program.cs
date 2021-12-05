namespace AoC2021.Day5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lineSegments = File.ReadAllLines(args[0]).Select(LineSegment.Parse).ToList();
            var points = new Dictionary<Point, int>();
            foreach (var line in lineSegments
                .Where(line => line.P1.X == line.P2.X || line.P1.Y == line.P2.Y))
            {
                foreach (var point in line.Points)
                {
                    if (!points.ContainsKey(point))
                    {
                        points[point] = 0;
                    }

                    points[point]++;
                }
            }

            var result = points.Count(x => x.Value > 1);
            Console.WriteLine($"Part 1: {result}");
            points.Clear();
            foreach (var line in lineSegments)
            {
                foreach (var point in line.Points)
                {
                    if (!points.ContainsKey(point))
                    {
                        points[point] = 0;
                    }

                    points[point]++;
                }
            }

            result = points.Count(x => x.Value > 1);
            Console.WriteLine($"Part 2: {result}");
        }
    }
}
