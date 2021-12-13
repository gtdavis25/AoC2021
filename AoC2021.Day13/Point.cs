using System.Text.RegularExpressions;

namespace AoC2021.Day13
{
    public readonly struct Point
    {
        public int X { get; init; }
        public int Y { get; init; }

        static readonly Regex Matcher = new(@"^(\d+),(\d+)$");

        public static Point Parse(string input)
        {
            var match = Matcher.Match(input);
            if (!match.Success)
            {
                throw new FormatException();
            }

            return new Point
            {
                X = int.Parse(match.Groups[1].Value),
                Y = int.Parse(match.Groups[2].Value)
            };
        }
    }
}
