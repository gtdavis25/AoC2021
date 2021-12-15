namespace AoC2021.Day15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllLines(args[0]);
            var width = input[0].Length;
            var height = input.Length;
            var map = new LocationMap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map.AddLocation(x, y, input[y][x] - '0');
                }
            }

            var start = map[0, 0];
            var end = map[map.Width - 1, map.Height - 1];
            var path = start.GetShortestPaths().First(path => path.End == end);
            Console.WriteLine($"Part 1: {path.TotalRisk}");
            map = new LocationMap(width * 5, height * 5);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            var risk = (input[y][x] - '0' + i + j - 1) % 9 + 1;
                            map.AddLocation(j * width + x, i * height + y, risk);
                        }
                    }
                }
            }

            start = map[0, 0];
            end = map[map.Width - 1, map.Height - 1];
            path = start.GetShortestPaths().First(path => path.End == end);
            Console.WriteLine($"Part 2: {path.TotalRisk}");
        }
    }
}
