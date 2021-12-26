namespace AoC2021.Day23
{
    public class SolverState
    {
        public Burrow Burrow { get; }
        public int Cost { get; }

        public SolverState(Burrow burrow, int cost)
        {
            Burrow = burrow;
            Cost = cost;
        }

        public IEnumerable<SolverState> GetNextStates()
        {
            foreach (var amphipod in Burrow.Amphipods)
            {
                foreach (var move in amphipod.GetMoves(Burrow))
                {
                    var next = Burrow.After(move);
                    yield return new SolverState(next, Cost + move.Cost);
                }
            }
        }

        public override string ToString()
        {
            return Burrow.ToString();
        }
    }
}
