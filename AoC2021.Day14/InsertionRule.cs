using System.Text.RegularExpressions;

namespace AoC2021.Day14
{
    public class InsertionRule
    {
        public string Pair { get; }
        public char InsertionChar { get; }

        public InsertionRule(string pair, char insertionChar)
        {
            Pair = pair;
            InsertionChar = insertionChar;
        }

        static readonly Regex Matcher = new(@"^([A-Z]{2}) -> ([A-Z])$");

        public static InsertionRule Parse(string line)
        {
            var match = Matcher.Match(line);
            if (!match.Success)
            {
                throw new FormatException();
            }

            var pair = match.Groups[1].Value;
            var insertionChar = match.Groups[2].Value[0];
            return new InsertionRule(pair, insertionChar);
        }
    }
}
