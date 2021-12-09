namespace AoC2021.Day9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var map = new HeightMap(File.ReadAllLines(args[0]));
            var lowPoints = map.GetLowPoints().ToList();
            var result = lowPoints.Sum(p => 1 + map.GetHeight(p));
            Console.WriteLine($"Part 1: {result}");
            result = lowPoints
                .Select(p => map.GetBasin(p).Count())
                .OrderByDescending(size => size)
                .Take(3)
                .Aggregate((x, y) => x * y);
            Console.WriteLine($"Part 2: {result}");
        }
    }
}
