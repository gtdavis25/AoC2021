using System.Text.RegularExpressions;

namespace AoC2021.Day24
{
    public class Computer
    {
        public Dictionary<string, long> Registers { get; set; } = new()
        {
            { "w", 0 },
            { "x", 0 },
            { "y", 0 },
            { "z", 0 }
        };

        private IEnumerator<long> _enumerator;

        public Computer(IEnumerable<long> input)
        {
            _enumerator = input.GetEnumerator();
        }

        const string InstructionPattern = @"^(inp|mul|add|div|eql|mod) ([w-z]|-?\d+)(?: ([w-z]|-?\d+))?$";

        static readonly Regex Matcher = new(InstructionPattern);

        public void Execute(string instruction)
        {
            var match = Matcher.Match(instruction);
            if (!match.Success)
            {
                throw new FormatException();
            }

            var arg1 = match.Groups[2].Value;
            string arg2;
            switch (match.Groups[1].Value)
            {
                case "inp":
                    _enumerator.MoveNext();
                    Registers[arg1] = _enumerator.Current;
                    break;

                case "add":
                    arg2 = match.Groups[3].Value;
                    Registers[arg1] += ResolveArgument(arg2);
                    break;

                case "mul":
                    arg2 = match.Groups[3].Value;
                    Registers[arg1] *= ResolveArgument(arg2);
                    break;

                case "div":
                    arg2 = match.Groups[3].Value;
                    Registers[arg1] /= ResolveArgument(arg2);
                    break;

                case "mod":
                    arg2 = match.Groups[3].Value;
                    Registers[arg1] %= ResolveArgument(arg2);
                    break;

                case "eql":
                    arg2 = match.Groups[3].Value;
                    Registers[arg1] = Registers[arg1] == ResolveArgument(arg2) ? 1 : 0;
                    break;

                default:
                    throw new Exception("Unsupported instruction: " + match.Groups[1].Value);
            }
        }

        private long ResolveArgument(string registerOrInteger)
        {
            if (long.TryParse(registerOrInteger, out var value))
            {
                return value;
            }

            return Registers[registerOrInteger];
        }

        public override string ToString()
        {
            return string.Join("\n", Registers.Select(reg => $"{reg.Key} = {reg.Value}"));
        }
    }
}
