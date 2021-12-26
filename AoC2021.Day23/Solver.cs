namespace AoC2021.Day23
{
    public class Solver
    {
        private Dictionary<string, SolverState> _shortestPaths;
        private PriorityQueue<SolverState, int> _queue;

        public Solver(Burrow burrow)
        {
            _shortestPaths = new();
            var initialState = new SolverState(burrow, 0);
            _queue = new();
            _queue.Enqueue(initialState, 0);
        }

        public int Solve()
        {
            while (_queue.Count > 0)
            {
                var state = _queue.Dequeue();
                if (state.Burrow.IsComplete())
                {
                    return state.Cost;
                }

                var key = state.ToString();
                if (_shortestPaths.ContainsKey(key))
                {
                    continue;
                }

                _shortestPaths[key] = state;
                foreach (var next in state.GetNextStates())
                {
                    if (_shortestPaths.ContainsKey(next.ToString()))
                    {
                        continue;
                    }

                    _queue.Enqueue(next, next.Cost);
                }
            }

            throw new Exception("No solutions");
        }
    }
}
