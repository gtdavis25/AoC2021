namespace AoC2021.Day22
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines(args[0]);
            var reactor = new Reactor();
            var steps = lines.Select(RebootStep.Parse);
            foreach (var step in steps)
            {
                reactor.ExecuteStep(step);
            }

            var area = new Cuboid(new Range(-50, 50), new Range(-50, 50), new Range(-50, 50));
            var activated = reactor.GetActivatedCubes(area);
            Console.WriteLine($"Part 1: {activated}");
            Console.WriteLine($"Part 2: {reactor.TotalCubes}");
        }
    }
}
