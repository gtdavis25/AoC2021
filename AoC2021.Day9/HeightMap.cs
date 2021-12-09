namespace AoC2021.Day9
{
    public class HeightMap
    {
        private int _width;
        private int _height;
        private byte[,] _cells;

        public HeightMap(string[] lines)
        {
            _height = lines.Length;
            _width = lines[0].Length;
            _cells = new byte[_width, _height];
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _cells[x, y] = (byte)(lines[y][x] - '0');
                }
            }
        }

        public IEnumerable<Point> GetLowPoints()
        {
            return GetPoints().Where(IsLowPoint);
        }

        public IEnumerable<Point> GetPoints()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    yield return new Point
                    {
                        X = x,
                        Y = y
                    };
                }
            }
        }

        public bool IsLowPoint(Point p)
        {
            CheckBounds(p);
            var height = GetHeight(p);
            return GetNeighbours(p).Select(GetHeight).All(neighbour => height < neighbour);
        }

        private void CheckBounds(Point p)
        {
            if (p.X < 0 || p.X >= _width || p.Y < 0 || p.Y >= _height)
            {
                throw new Exception("Out of bounds");
            }
        }

        public int GetHeight(Point p)
        {
            CheckBounds(p);
            return _cells[p.X, p.Y];
        }

        public IEnumerable<Point> GetNeighbours(Point p)
        {
            CheckBounds(p);
            if (p.Y > 0)
            {
                yield return new Point { X = p.X, Y = p.Y - 1 };
            }

            if (p.X > 0)
            {
                yield return new Point { X = p.X - 1, Y = p.Y };
            }

            if (p.X + 1 < _width)
            {
                yield return new Point { X = p.X + 1, Y = p.Y };
            }

            if (p.Y + 1 < _height)
            {
                yield return new Point { X = p.X, Y = p.Y + 1 };
            }
        }

        public IEnumerable<Point> GetBasin(Point p)
        {
            CheckBounds(p);
            if (GetHeight(p) > 8)
            {
                throw new Exception("Point does not belong to a basin");
            }

            var basin = new List<Point>();
            var seen = new HashSet<Point> { p };
            var queue = new Queue<Point>(seen);
            while (queue.Count > 0)
            {
                p = queue.Dequeue();
                if (GetHeight(p) > 8)
                {
                    continue;
                }

                basin.Add(p);
                foreach (var neighbour in GetNeighbours(p))
                {
                    if (seen.Contains(neighbour))
                    {
                        continue;
                    }

                    seen.Add(neighbour);
                    queue.Enqueue(neighbour);
                }
            }

            return basin;
        }
    }
}
