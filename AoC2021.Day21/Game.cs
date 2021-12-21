namespace AoC2021.Day21
{
    public class Game
    {
        public int[] Squares { get; set; }
        public int[] Scores { get; set; }
        public int Turn { get; set; }

        public Game(int[] squares)
        {
            Squares = squares;
            Scores = new[] { 0, 0 };
        }

        public Game(Game previous, int[] rolls)
        {
            Squares = previous.Squares.ToArray();
            Scores = previous.Scores.ToArray();
            Squares[previous.Turn] = (Squares[previous.Turn] + rolls.Sum() - 1) % 10 + 1;
            Scores[previous.Turn] += Squares[previous.Turn];
            Turn = previous.Turn ^ 1;
        }

        private static int[][]? _rolls;
        public static IEnumerable<int[]> Rolls
        {
            get
            {
                if (_rolls is null)
                {
                    _rolls = new int[27][];
                    for (int i = 0; i < _rolls.Length; i++)
                    {
                        _rolls[i] = new int[3];
                        var t = i;
                        for (int j = 0; j < _rolls[i].Length; j++)
                        {
                            _rolls[i][j] = t % 3 + 1;
                            t /= 3;
                        }
                    }
                }

                return _rolls;
            }
        }

        private static Dictionary<string, GameResult> _memo = new();

        public GameResult GetResult()
        {
            var key = ToString();
            if (!_memo.ContainsKey(key))
            {
                _memo[key] = GetResultImpl();
            }

            return _memo[key];
        }

        private GameResult GetResultImpl()
        {
            if (Scores[0] >= 21)
            {
                return new GameResult { Player1Wins = 1 };
            }
            else if (Scores[1] >= 21)
            {
                return new GameResult { Player2Wins = 1 };
            }
            else
            {
                var result = new GameResult();
                foreach (var roll in Rolls)
                {
                    result += new Game(this, roll).GetResult();
                }

                return result;
            }
        }

        public override string ToString()
        {
            return $"{string.Join(",", Squares)}:{string.Join(",", Scores)}:{Turn}";
        }
    }
}
