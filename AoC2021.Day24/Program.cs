using System.Text.RegularExpressions;

namespace AoC2021.Day24
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(args[0]);
            long[] digits = { 1, 1, 2, 1, 1, 7, 9, 1, 1, 1, 1, 3, 6, 5 };
            var result = GetResult(input, digits);
            Console.WriteLine($"{string.Join(string.Empty, digits)} -> {result}");
        }

        public static long GetResult(string[] instructions, long[] digits)
        {
            var computer = new Computer(digits);
            foreach (var instruction in instructions)
            {
                computer.Execute(instruction);
            }

            return computer.Registers["z"];
        }
    }
}
