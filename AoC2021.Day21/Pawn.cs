namespace AoC2021.Day21
{
    public class Pawn
    {
        public int Position { get; set; }
        public int Score { get; set; }

        public Pawn(int start)
        {
            Position = start;
        }

        public void Move(int squares)
        {
            Position = (Position + squares - 1) % 10 + 1;
            Score += Position;
        }
    }
}
