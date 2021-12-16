namespace AoC2021.Day16
{
    public class BitStream
    {
        private byte[] _data;
        private int _cursor;

        public bool EndOfStream => _cursor >= _data.Length * 8;

        public BitStream(string input)
        {
            _data = Convert.FromHexString(input);
        }

        public long ReadBits(int numBits)
        {
            if (numBits < 1 || numBits > 32)
            {
                throw new ArgumentOutOfRangeException(nameof(numBits));
            }

            var value = 0L;
            for (int i = 0; i < numBits; i++)
            {
                value <<= 1;
                value += NextBit();
            }

            return value;
        }

        private int NextBit()
        {
            if (EndOfStream)
            {
                throw new Exception($"Reached end of bit stream");
            }

            var word = _data[_cursor / 8];
            var offset = 7 - (_cursor++ % 8);
            return (word >> offset) & 1;
        }
    }
}
