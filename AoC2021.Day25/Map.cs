using System.Text;

namespace AoC2021.Day25
{
    public class Map
    {
        private char[,] _map;

        public int Width { get; }
        public int Height { get; }

        public Map(string[] lines)
        {
            Width = lines[0].Length;
            Height = lines.Length;
            _map = new char[Width, Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    _map[x, y] = lines[y][x];
                }
            }
        }

        public bool NextState()
        {
            var state = ToString();
            ShiftRight();
            ShiftDown();
            return state != ToString();
        }

        public void ShiftRight()
        {
            var next = new char[Width, Height];
            ForEachCell((x, y) => next[x, y] = _map[x, y]);
            ForEachCell((x, y) =>
            {
                if (_map[x, y] == '>' && _map[(x + 1) % Width, y] == '.')
                {
                    next[x, y] = '.';
                    next[(x + 1) % Width, y] = '>';
                }
            });

            _map = next;
        }

        public void ShiftDown()
        {
            var next = new char[Width, Height];
            ForEachCell((x, y) => next[x, y] = _map[x, y]);
            ForEachCell((x, y) =>
            {
                if (_map[x, y] == 'v' && _map[x, (y + 1) % Height] == '.')
                {
                    next[x, y] = '.';
                    next[x, (y + 1) % Height] = 'v';
                }
            });

            _map = next;
        }

        private void ForEachCell(Action<int, int> action)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    action(x, y);
                }
            }
        }

        public override string ToString()
        {
            var lines = new string[Height];
            var builder = new StringBuilder();
            for (int y = 0; y < lines.Length; y++)
            {
                builder.Clear();
                for (int x = 0; x < Width; x++)
                {
                    builder.Append(_map[x, y]);
                }

                lines[y] = builder.ToString();
            }

            return string.Join("\n", lines);
        }
    }
}
