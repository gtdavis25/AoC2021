namespace AoC2021.Day18
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(args[0]);
            var reader = new NumberReader();
            var numbers = input.Select(reader.Read).ToList();
            var result = numbers.Aggregate((n1, n2) => n1.Clone().Add(n2.Clone()));
            Console.WriteLine($"Part 1: {result.Magnitude}");
            var maxSum = GetPairwiseSums(numbers).Max(sum => sum.Magnitude);
            Console.WriteLine($"Part 2: {maxSum}");
        }

        public static IEnumerable<Number> GetPairwiseSums(IList<Number> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (i != j)
                    {
                        yield return numbers[i].Clone().Add(numbers[j].Clone());
                    }
                }
            }
        }
    }
}
