namespace AoC2021.Day12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var caves = new CaveMap(File.ReadAllLines(args[0]));
            var result = caves.GetRoutes("start", "end").Count();
            Console.WriteLine($"Part 1: {result}");
            result = caves.GetRoutes("start", "end", 1).Count();
            Console.WriteLine($"Part 2: {result}");
        }
    }
}
