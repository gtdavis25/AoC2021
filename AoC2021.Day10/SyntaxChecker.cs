namespace AoC2021.Day10
{
    public class SyntaxChecker
    {
        private int _score;

        public int Score => _score;

        public List<long> AutocompleteScores { get; set; } = new();

        public void Check(string line)
        {
            var chunks = new Stack<char>();
            for (int i = 0; i < line.Length; i++)
            {
                if (IsOpeningChar(line[i]))
                {
                    chunks.Push(line[i]);
                }
                else if (chunks.Count == 0 || chunks.Peek() != GetOpeningChar(line[i]))
                {
                    _score += GetScore(line[i]);
                    return;
                }
                else
                {
                    chunks.Pop();
                }
            }

            long score = 0;
            while (chunks.Count() > 0)
            {
                score = score * 5 + GetAutocompleteScore(chunks.Pop());
            }

            AutocompleteScores.Add(score);
        }

        public bool IsOpeningChar(char ch)
        {
            return ch == '(' || ch == '[' || ch == '{' || ch == '<';
        }

        public char GetOpeningChar(char closingChar)
        {
            switch (closingChar)
            {
                case ')':
                    return '(';

                case ']':
                    return '[';

                case '}':
                    return '{';

                case '>':
                    return '<';

                default:
                    throw new Exception("No such closing char: " + closingChar);
            }
        }

        public int GetScore(char ch)
        {
            switch (ch)
            {
                case ')':
                    return 3;

                case ']':
                    return 57;

                case '}':
                    return 1197;

                case '>':
                    return 25137;

                default:
                    throw new Exception("No such closing char");
            }
        }

        public int GetAutocompleteScore(char ch)
        {
            switch (ch)
            {
                case '(':
                    return 1;

                case '[':
                    return 2;

                case '{':
                    return 3;

                case '<':
                    return 4;

                default:
                    throw new Exception("Invalid opening char: " + ch);
            }
        }
    }
}
