using System.Text;

namespace AoC2021.Day14
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(args[0]);
            var polymer = input[0];
            var rules = input.Skip(2).Select(InsertionRule.Parse);
            var polymerizer = new Polymerizer(rules);
            var frequencies = polymerizer.GetFrequencies(polymer, 10);
            var result = frequencies.Values.Max() - frequencies.Values.Min();
            Console.WriteLine($"Part 1: {result}");
            frequencies = polymerizer.GetFrequencies(polymer, 40);
            result = frequencies.Values.Max() - frequencies.Values.Min();
            Console.WriteLine($"Part 2: {result}");
        }
    }
}
