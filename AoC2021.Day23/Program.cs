namespace AoC2021.Day23
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(args[0]);
            var burrow = Burrow.Parse(input);
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var solver = new Solver(burrow);
            var result = solver.Solve();
            Console.WriteLine(result);
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
