using System.Text.RegularExpressions;

namespace AoC2021.Day13
{
    public class Fold
    {
        public FoldDirection Direction { get; set; }
        public int Offset { get; set; }

        static readonly Regex Matcher = new(@"^fold along ([xy])=(\d+)$");

        public Fold(string line)
        {
            var match = Matcher.Match(line);
            if (!match.Success)
            {
                throw new FormatException();
            }

            Direction = match.Groups[1].Value == "x" ? FoldDirection.X : FoldDirection.Y;
            Offset = int.Parse(match.Groups[2].Value);
        }
    }
}
