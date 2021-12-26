namespace AoC2021.Day23
{
    public class Move
    {
        public Amphipod Amphipod { get; }
        public Point To { get; }
        public int Length { get; }

        public int X => To.X;
        public int Y => To.Y;
        public int Cost
        {
            get
            {
                var cost = Length;
                for (int i = Amphipod.AmphipodType - 'A'; i > 0; i--)
                {
                    cost *= 10;
                }

                return cost;
            }
        }

        public Move(Amphipod amphipod, Point to, int length)
        {
            Amphipod = amphipod;
            To = to;
            Length = length;
        }
    }
}
