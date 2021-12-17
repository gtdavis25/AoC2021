using System.Text.RegularExpressions;

namespace AoC2021.Day17
{
    public class Program
    {
        static readonly Regex Matcher = new(@"^target area: x=(-?\d+)\.\.(-?\d+), y=(-?\d+)..(-\d+)$");

        public static void Main(string[] args)
        {
            var input = File.ReadAllText(args[0]).Trim();
            var match = Matcher.Match(input);
            if (!match.Success)
            {
                throw new FormatException();
            }

            var minX = int.Parse(match.Groups[1].Value);
            var maxX = int.Parse(match.Groups[2].Value);
            var minY = int.Parse(match.Groups[3].Value);
            var maxY = int.Parse(match.Groups[4].Value);
            var targetArea = new Rectangle(minX, minY, maxX - minX, maxY - minY);
            var origin = new Vector(0, 0);
            var highest = 0;
            var hitCount = 0;
            for (int dy = -200; dy <= 200; dy++)
            {
                for (int dx = 0; dx <= targetArea.X + targetArea.Width; dx++)
                {
                    var velocity = new Vector(dx, dy);
                    var projectile = new Projectile(origin, velocity);
                    var trajectory = projectile.PlotTrajectory()
                        .TakeWhile(p => p.X <= targetArea.X + targetArea.Width && p.Y >= targetArea.Y)
                        .ToList();
                    if (trajectory.Any(targetArea.Contains))
                    {
                        hitCount++;
                        var max = trajectory.Max(p => p.Y);
                        if (max > highest)
                        {
                            highest = max;
                        }
                    }
                }
            }

            Console.WriteLine($"Part 1: {highest}");
            Console.WriteLine($"Part 2: {hitCount}");
        }
    }
}
