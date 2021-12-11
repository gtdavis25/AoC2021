namespace AoC2021.Day11
{
    public class Grid
    {
        private int _width;
        private int _height;
        private byte[,] _octopuses;
        private int _flashes;
        private int _steps;

        public int Steps => _steps;

        public Grid(string[] rows)
        {
            _width = rows[0].Length;
            _height = rows.Length;
            _octopuses = new byte[_width, _height];
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _octopuses[x, y] = (byte)(rows[y][x] - '0');
                }
            }
        }

        public int Step()
        {
            _flashes = 0;
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _octopuses[x, y]++;
                    if (_octopuses[x, y] == 10)
                    {
                        Flash(x, y);
                    }
                }
            }

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_octopuses[x, y] > 9)
                    {
                        _octopuses[x, y] = 0;
                    }
                }
            }

            _steps++;
            return _flashes;
        }

        private void Flash(int x, int y)
        {
            _flashes++;
            for (int y1 = y - 1; y1 <= y + 1; y1++)
            {
                for (int x1 = x - 1; x1 <= x + 1; x1++)
                {
                    if (0 <= x1 && x1 < _width && 0 <= y1 && y1 < _height && (x1 != x || y1 != y))
                    {
                        _octopuses[x1, y1]++;
                        if (_octopuses[x1, y1] == 10)
                        {
                            Flash(x1, y1);
                        }
                    }
                }
            }
        }
    }
}
