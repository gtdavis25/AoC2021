namespace AoC2021.Day8
{
    public class Unscrambler
    {
        public int Unscramble(Display display)
        {
            var lookup = GetLookup(display.Patterns.Select(MapToByte).ToList());
            return display.Output
                .Select(s => Array.IndexOf(lookup, MapToByte(s)))
                .Aggregate((x, y) => x * 10 + y);
        }

        private byte[] GetLookup(List<byte> signals)
        {
            var lookup = new byte[10];
            lookup[1] = Take(signals, b => GetBitCount(b) == 2);
            lookup[4] = Take(signals, b => GetBitCount(b) == 4);
            lookup[7] = Take(signals, b => GetBitCount(b) == 3);
            lookup[8] = Take(signals, b => GetBitCount(b) == 7);
            lookup[9] = Take(signals, b => GetBitCount(b) == 6 && GetBitCount((byte)(b & lookup[4])) == 4);
            lookup[0] = Take(signals, b => GetBitCount(b) == 6 && GetBitCount((byte)(b & lookup[7])) == 3);
            lookup[6] = Take(signals, b => GetBitCount(b) == 6);
            lookup[3] = Take(signals, b => GetBitCount((byte)(b & lookup[1])) == 2);
            lookup[5] = Take(signals, b => GetBitCount((byte)(b & lookup[9])) == 5);
            lookup[2] = Take(signals, b => true);
            return lookup;
        }

        private byte Take(List<byte> bytes, Func<byte, bool> predicate)
        {
            foreach (var b in bytes)
            {
                if (predicate(b))
                {
                    bytes.Remove(b);
                    return b;
                }
            }

            throw new Exception("Not found");
        }

        private byte MapToByte(string s)
        {
            byte value = 0;
            foreach (var ch in s)
            {
                value += (byte)(1 << (ch - 'a'));
            }

            return value;
        }

        private int GetBitCount(byte b)
        {
            var count = 0;
            while (b > 0)
            {
                b = (byte)(b & (b - 1));
                count++;
            }

            return count;
        }
    }
}
