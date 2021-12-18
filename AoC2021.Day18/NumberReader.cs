namespace AoC2021.Day18
{
    public class NumberReader
    {
        public Number Read(string s)
        {
            return Read(new StringReader(s));
        }

        public Number Read(TextReader reader)
        {
            var ch = (char)reader.Read();
            if (char.IsDigit(ch))
            {
                return new RegularNumber(ch - '0');
            }

            AssertEqual('[', ch);
            var leftChild = Read(reader);
            AssertEqual(',', (char)reader.Read());
            var rightChild = Read(reader);
            AssertEqual(']', (char)reader.Read());
            return new SnailfishNumber(leftChild, rightChild);
        }

        private void AssertEqual(char expected, char got)
        {
            if (got != expected)
            {
                throw new Exception($"Expected {expected}, got {got}");
            }
        }
    }
}
