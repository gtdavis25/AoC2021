namespace AoC2021.Day4
{
    public class Board
    {
        private int _width;
        private int _height;
        private int[,] _cells;

        public int Sum
        {
            get
            {
                var sum = 0;
                for (int y = 0; y < _height; y++)
                {
                    for (int x = 0; x < _width; x++)
                    {
                        if (_cells[x, y] != -1)
                        {
                            sum += _cells[x, y];
                        }
                    }
                }

                return sum;
            }
        }

        public Board(int[][] cells)
        {
            _width = cells[0].Length;
            _height = cells[0].Length;
            _cells = new int[_width, _height];
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _cells[x, y] = cells[y][x];
                }
            }
        }

        public void Draw(int value)
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (_cells[x, y] == value)
                    {
                        _cells[x, y] = -1;
                    }
                }
            }
        }

        public bool IsComplete()
        {
            for (int y = 0; y < _height; y++)
            {
                var complete = true;
                for (int x = 0; x < _width; x++)
                {
                    if (_cells[x, y] != -1)
                    {
                        complete = false;
                        break;
                    }
                }

                if (complete)
                {
                    return true;
                }
            }

            for (int x = 0; x < _width; x++)
            {
                var complete = true;
                for (int y = 0; y < _height; y++)
                {
                    if (_cells[x, y] != -1)
                    {
                        complete = false;
                        break;
                    }
                }

                if (complete)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
