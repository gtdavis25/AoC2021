namespace AoC2021.Day25
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(args[0]);
            var map = new Map(input);
            var t = 1;
            while (map.NextState())
            {
                t++;
            }

            Console.WriteLine($"{t}");
        }
    }
}
