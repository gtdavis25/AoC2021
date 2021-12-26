namespace AoC2021.Day23
{
    public class Burrow
    {
        private char[,] _map;
        private List<Amphipod> _amphipods;

        public int Width => _map.GetLength(0);
        public int Height => _map.GetLength(1);
        public char this[int x, int y] => _map[x, y];
        public IEnumerable<Amphipod> Amphipods => _amphipods;

        public Burrow(char[,] map, IEnumerable<Amphipod> amphipods)
        {
            _map = map;
            _amphipods = amphipods.ToList();
        }

        public static Burrow Parse(string[] lines)
        {
            var height = lines.Length;
            var width = lines[0].Length;
            var map = new char[width, height];
            var amphipods = new List<Amphipod>();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x >= lines[y].Length)
                    {
                        map[x, y] = ' ';
                        continue;
                    }

                    var ch = lines[y][x];
                    switch (ch)
                    {
                        case '#':
                        case '.':
                        case ' ':
                            map[x, y] = ch;
                            break;

                        case 'A':
                        case 'B':
                        case 'C':
                        case 'D':
                            map[x, y] = '.';
                            amphipods.Add(new Amphipod(new Point(x, y), ch));
                            break;

                        default:
                            throw new Exception("Unexpected character in input");
                    }
                }
            }

            return new Burrow(map, amphipods);
        }

        public Burrow After(Move move)
        {
            var amphipods = Amphipods
                .Where(amphipod => amphipod != move.Amphipod)
                .Append(new Amphipod(move.To, move.Amphipod.AmphipodType));

            return new Burrow(_map, amphipods);
        }

        public Amphipod? GetAmphipod(Point position)
        {
            return Amphipods.FirstOrDefault(a => a.Position.Equals(position));
        }

        public bool IsComplete()
        {
            foreach (var amphipod in Amphipods)
            {
                if (amphipod.Position.X != 2 * (amphipod.AmphipodType - 'A') + 3)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            var lines = new char[Height][];
            for (int y = 0; y < Height; y++)
            {
                lines[y] = new char[Width];
                for (int x = 0; x < Width; x++)
                {
                    lines[y][x] = _map[x, y];
                }
            }

            foreach (var a in _amphipods)
            {
                lines[a.Position.Y][a.Position.X] = a.AmphipodType;
            }

            return string.Join("\n", lines.Select(line => new string(line)));
        }
    }
}
