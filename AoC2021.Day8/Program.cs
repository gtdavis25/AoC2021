namespace AoC2021.Day8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var displays = File.ReadAllLines(args[0]).Select(line => new Display(line));
            var result = displays.SelectMany(display => display.Output)
                .Count(s => s.Length == 2 || s.Length == 3 || s.Length == 4 || s.Length == 7);
            Console.WriteLine($"Part 1: {result}");
            result = 0;
            var unscrambler = new Unscrambler();
            foreach (var display in displays)
            {
                result += unscrambler.Unscramble(display);
            }

            Console.WriteLine($"Part 2: {result}");
        }
    }
}
