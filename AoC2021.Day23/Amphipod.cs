namespace AoC2021.Day23
{
    public class Amphipod
    {
        public Point Position { get; }
        public char AmphipodType { get; }

        public int DestinationX => 2 * (AmphipodType - 'A') + 3;

        public Amphipod(Point position, char amphipodType)
        {
            Position = position;
            AmphipodType = amphipodType;
        }

        public IEnumerable<Move> GetMoves(Burrow burrow)
        {
            if (IsDestination(burrow, Position))
            {
                yield break;
            }

            var seen = new HashSet<Point>(Position.AdjacentPoints);
            var queue = new Queue<Move>(Position.AdjacentPoints.Select(p => new Move(this, p, 1)));
            while (queue.Count > 0)
            {
                var move = queue.Dequeue();
                if (!CanTraverse(burrow, move.To))
                {
                    continue;
                }

                foreach (var p in move.To.AdjacentPoints)
                {
                    if (seen.Contains(p))
                    {
                        continue;
                    }

                    seen.Add(p);
                    queue.Enqueue(new Move(this, p, move.Length + 1));
                }

                if (CanStop(burrow, move.To))
                {
                    yield return move;
                }
            }
        }

        private bool CanTraverse(Burrow burrow, Point point)
        {
            if (burrow[point.X, point.Y] != '.')
            {
                return false;
            }

            if (burrow.GetAmphipod(point) != null)
            {
                return false;
            }

            return true;
        }

        private bool CanStop(Burrow burrow, Point point)
        {
            if (point.Y == 1)
            {
                if (Position.Y == 1)
                {
                    return false;
                }

                if (3 <= point.X && point.X <= 9 && point.X % 2 == 1)
                {
                    return false;
                }
            }
            else
            {
                if (!IsDestination(burrow, point))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsDestination(Burrow burrow, Point point)
        {
            if (point.X != 2 * (AmphipodType - 'A') + 3)
            {
                return false;
            }

            for (int y = point.Y + 1; y + 1 < burrow.Height; y++)
            {
                var p = new Point(point.X, y);
                if (burrow.GetAmphipod(p)?.AmphipodType != AmphipodType)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
