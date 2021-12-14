using System.Text;

namespace AoC2021.Day14
{
    public class Polymerizer
    {
        private Dictionary<string, Dictionary<char, long>> _memo = new();

        public Dictionary<string, InsertionRule> Rules { get; set; }

        public Polymerizer(IEnumerable<InsertionRule> rules)
        {
            Rules = rules.ToDictionary(rule => rule.Pair);
        }

        public Dictionary<char, long> GetFrequencies(string polymer, int iterations)
        {
            if (iterations < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(iterations));
            }

            if (iterations == 0)
            {
                return polymer
                    .GroupBy(ch => ch)
                    .ToDictionary(group => group.Key, group => group.LongCount());
            }

            var key = $"{polymer}:{iterations}";
            if (_memo.ContainsKey(key))
            {
                return _memo[key];
            }

            var frequencies = new Dictionary<char, long>();
            var transformed = Transform(polymer);
            for (int i = 0; i + 1 < transformed.Length; i++)
            {
                foreach (var (ch, count) in GetFrequencies(transformed.Substring(i, 2), iterations - 1))
                {
                    if (!frequencies.ContainsKey(ch))
                    {
                        frequencies[ch] = 0;
                    }

                    frequencies[ch] += count;
                }

                if (i > 0)
                {
                    frequencies[transformed[i]]--;
                }
            }

            _memo[key] = frequencies;
            return frequencies;
        }

        public string Transform(string polymer)
        {
            var builder = new StringBuilder();
            for (int i = 0; i + 1 < polymer.Length; i++)
            {
                builder.Append(polymer[i]);
                builder.Append(Rules[polymer.Substring(i, 2)].InsertionChar);
            }

            builder.Append(polymer[polymer.Length - 1]);
            return builder.ToString();
        }
    }
}
