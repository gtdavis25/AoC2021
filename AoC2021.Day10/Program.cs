namespace AoC2021.Day10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines(args[0]);
            var checker = new SyntaxChecker();
            foreach (var line in lines)
            {
                checker.Check(line);
            }

            Console.WriteLine($"Part 1: {checker.Score}");
            checker.AutocompleteScores.Sort();
            Console.WriteLine($"Part 2: {checker.AutocompleteScores[checker.AutocompleteScores.Count / 2]}");
        }
    }
}
