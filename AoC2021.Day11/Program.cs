namespace AoC2021.Day11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var grid = new Grid(File.ReadAllLines(args[0]));
            var flashes = 0;
            for (int i = 0; i < 100; i++)
            {
                flashes += grid.Step();
            }

            Console.WriteLine($"Part 1: {flashes}");
            while (grid.Step() < 100) ;
            Console.WriteLine($"Part 2: {grid.Steps}");
        }
    }
}
