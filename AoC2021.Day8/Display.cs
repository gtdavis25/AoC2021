using System.Text.RegularExpressions;

namespace AoC2021.Day8
{
    public class Display
    {
        public string[] Patterns { get; set; }
        public string[] Output { get; set; }

        static readonly Regex InputMatcher = new(@"^([a-g]+(?: [a-g]+){9}) \| ([a-z]+(?: [a-z]+){3})$");

        public Display(string input)
        {
            var match = InputMatcher.Match(input);
            if (!match.Success)
            {
                throw new FormatException();
            }

            Patterns = match.Groups[1].Value.Split();
            Output = match.Groups[2].Value.Split();
        }
    }
}
